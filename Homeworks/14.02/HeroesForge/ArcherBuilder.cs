namespace HeroesForge;

class ArcherBuilder : ISetName<Archer, int>, ISetHealth<Archer, int>, ISetAttack<Archer, int>, ISetUnique<Archer, int>, IBuild<Archer>
{
    private Archer _archer = new Archer();

    private ArcherBuilder() { }

    public static ISetName<Archer, int> CreateBuilder()
    {
        return new ArcherBuilder();
    }

    public ISetHealth<Archer, int> SetName(string name)
    {
        _archer.Name = name;
        return this;
    }

    public ISetAttack<Archer, int> SetHealth(int health)
    {
        _archer.Health = health;
        return this;
    }

    public ISetUnique<Archer, int> SetAttack(int attack)
    {
        _archer.Attack = attack;
        return this;
    }

    public IBuild<Archer> SetUnique(int value)
    {
        _archer.ShotDistance = value;
        return this;
    }

    public Archer Build()
    {
        return _archer;
    }
}