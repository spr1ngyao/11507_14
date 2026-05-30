namespace HeroesForge;

class MageBuilder : ISetName<Mage, int>, ISetHealth<Mage, int>, ISetAttack<Mage, int>, ISetUnique<Mage, int>, IBuild<Mage>
{
    private Mage _mage = new Mage();

    private MageBuilder() { }

    public static ISetName<Mage, int> CreateBuilder()
    {
        return new MageBuilder();
    }

    public ISetHealth<Mage, int> SetName(string name)
    {
        _mage.Name = name;
        return this;
    }

    public ISetAttack<Mage, int> SetHealth(int health)
    {
        _mage.Health = health;
        return this;
    }

    public ISetUnique<Mage, int> SetAttack(int attack)
    {
        _mage.Attack = attack;
        return this;
    }

    public IBuild<Mage> SetUnique(int value)
    {
        _mage.Mana = value;
        return this;
    }

    public Mage Build()
    {
        return _mage;
    }
}