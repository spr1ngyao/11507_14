namespace HeroesForge;

interface ISetName<T, U> where T : Hero
{
    ISetHealth<T, U> SetName(string name);
}

interface ISetHealth<T, U> where T : Hero
{
    ISetAttack<T, U> SetHealth(int health);
}

interface ISetAttack<T, U> where T : Hero
{
    ISetUnique<T, U> SetAttack(int attack);
}

interface ISetUnique<T, U> where T : Hero
{
    IBuild<T> SetUnique(U value);
}

interface IBuild<T> where T : Hero
{
    T Build();
}