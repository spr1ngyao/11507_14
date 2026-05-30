namespace DotaFilter;

public static class HeroExtensions
{
    public static IEnumerable<Hero> Filter(this IEnumerable<Hero> source, int difficulty)
    {
        return source.Where(h => h.Difficulty == difficulty);
    }
}