namespace HeroesForge;

class Program
{
    static void Main(string[] args)
    {
        Warrior warrior = WarriorBuilder.CreateBuilder()
            .SetName("Conan")
            .SetHealth(100)
            .SetAttack(50)
            .SetUnique("Sword of Fire")
            .Build();

        Mage mage = MageBuilder.CreateBuilder()
            .SetName("Gandalf")
            .SetHealth(70)
            .SetAttack(80)
            .SetUnique(200)
            .Build();

        Archer archer = ArcherBuilder.CreateBuilder()
            .SetName("Legolas")
            .SetHealth(80)
            .SetAttack(60)
            .SetUnique(150)
            .Build();

        Console.WriteLine($"Warrior: {warrior.Name}, HP: {warrior.Health}, ATK: {warrior.Attack}, Weapon: {warrior.WeaponName}");
        Console.WriteLine($"Mage: {mage.Name}, HP: {mage.Health}, ATK: {mage.Attack}, Mana: {mage.Mana}");
        Console.WriteLine($"Archer: {archer.Name}, HP: {archer.Health}, ATK: {archer.Attack}, ShotDist: {archer.ShotDistance}");
    }
}