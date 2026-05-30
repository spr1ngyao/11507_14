using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQ;

class Program
{
    static void Main(string[] args)
    {
    }

    // LQ1
    public static T[] ShiftLeft<T>(T[] arr, int k)
    {
        if (arr == null || arr.Length == 0) return arr;
        
        int shift = k % arr.Length;
        if (shift < 0) shift += arr.Length;
        
        return arr.Skip(shift).Concat(arr.Take(shift)).ToArray();
    }

    // LQ2
    public static IEnumerable<(int X, int Y)> Get1Neighborhood(IEnumerable<(int X, int Y)> points)
    {
        var offsets = new[] { (-1, -1), (-1, 0), (-1, 1),
            ( 0, -1),          ( 0, 1),
            ( 1, -1), ( 1, 0), ( 1, 1) };

        return points
            .SelectMany(p => offsets.Select(o => (p.X + o.X, p.Y + o.Y)))
            .Distinct();
    }
    
    // LQ3
    public static IEnumerable<string> FilterStrings(IEnumerable<string> strings)
    {
        return strings.Where(s => s
            .GroupBy(char.ToLowerInvariant)
            .All(group => group.Count() <= 2));
    }
    
    // LQ4
    public class Hamming1Searcher
    {
        private const char Wildcard = '\0'; 
        private readonly Dictionary<string, HashSet<string>> _index = new();
        private readonly int _k;

        public Hamming1Searcher(IEnumerable<string> words)
        {
            var first = words.FirstOrDefault();
            _k = first?.Length ?? 0;
        
            foreach (var word in words)
            {
                for (int i = 0; i < _k; i++)
                {
                    var key = word.Substring(0, i) + Wildcard + word.Substring(i + 1);
                
                    if (!_index.TryGetValue(key, out var bucket))
                        _index[key] = bucket = new HashSet<string>();
                    
                    bucket.Add(word);
                }
            }
        }
    
        public IEnumerable<string> Find(string query)
        {
            var result = new HashSet<string>();
        
            for (int i = 0; i < _k; i++)
            {
                var key = query.Substring(0, i) + Wildcard + query.Substring(i + 1);
            
                if (_index.TryGetValue(key, out var bucket))
                {
                    foreach (var word in bucket)
                        if (word != query)
                            result.Add(word);
                }
            }
            return result;
        }
    }
}