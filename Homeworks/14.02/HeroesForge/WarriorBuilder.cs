namespace HeroesForge;

class WarriorBuilder : ISetName<Warrior, string>, ISetHealth<Warrior, string>, ISetAttack<Warrior, string>, ISetUnique<Warrior, string>, IBuild<Warrior>
{
    private Warrior _warrior = new Warrior();

    private WarriorBuilder() { }

    public static ISetName<Warrior, string> CreateBuilder()
    {
        return new WarriorBuilder();
    }

    public ISetHealth<Warrior, string> SetName(string name)
    {
        _warrior.Name = name;
        return this;
    }

    public ISetAttack<Warrior, string> SetHealth(int health)
    {
        _warrior.Health = health;
        return this;
    }

    public ISetUnique<Warrior, string> SetAttack(int attack)
    {
        _warrior.Attack = attack;
        return this;
    }

    public IBuild<Warrior> SetUnique(string value)
    {
        _warrior.WeaponName = value;
        return this;
    }

    public Warrior Build()
    {
        return _warrior;
    }
}