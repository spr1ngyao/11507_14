using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotaFilter;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "heroes.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл '{filePath}' не найден. Положите его рядом с .exe или укажите полный путь.");
            return;
        }
        
        var heroes = File.ReadLines(filePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Split(';'))
            .Where(parts => parts.Length >= 8)
            .Select(parts =>
            {
                bool TryInt(string s, out int val) => int.TryParse(s.Trim(), out val);
                
                if (TryInt(parts[1], out int diff) && 
                    TryInt(parts[4], out int hp) && 
                    TryInt(parts[5], out int str) && 
                    TryInt(parts[6], out int agi) && 
                    TryInt(parts[7], out int intel))
                {
                    return new Hero
                    {
                        Name = parts[0].Trim(),
                        Difficulty = diff,
                        Attribute = parts[2].Trim(),
                        AttackType = parts[3].Trim(),
                        MinHP = hp,
                        BaseStr = str,
                        BaseAgi = agi,
                        BaseInt = intel
                    };
                }
                return null;
            })
            .Where(h => h != null)
            .ToList();
        
            int targetDifficulty = 2;
            string targetAttributeRu = "Ловкость";

            // 3️⃣ Применение .Filter(Сложность)
            var filtered = heroes.Filter(targetDifficulty);
            
            string targetAttributeEn = MapAttribute(targetAttributeRu);
            filtered = filtered.Where(h => 
                h.Attribute.Equals(targetAttributeEn, StringComparison.OrdinalIgnoreCase));
            
            var result = filtered.OrderBy(h => h.MinHP).ToList();
            
            Console.WriteLine($"Результат: Сложность={targetDifficulty}, Атрибут={targetAttributeRu}");
            Console.WriteLine(new string('-', 80));
            if (!result.Any())
            {
                Console.WriteLine("Герои не найдены по заданным критериям.");
                return;
            }

            foreach (var h in result)
            {
                Console.WriteLine($"{h.Name,-18} | {h.Attribute,-12} | HP: {h.MinHP,-3} | Str:{h.BaseStr} Agi:{h.BaseAgi} Int:{h.BaseInt}");
            }
    }
    
    static string MapAttribute(string ru) => ru.Trim().ToLower() switch
    {
        "ловкость" => "Agility",
        "сила" => "Strength",
        "интеллект" => "Intelligence",
        _ => ru
    };
}