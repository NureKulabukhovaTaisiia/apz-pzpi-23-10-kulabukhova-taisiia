using System;

var hero = new Character();

while (true)
{
    Console.WriteLine("\nОберiть дiю:");
    Console.WriteLine("1 — Атака мечем");
    Console.WriteLine("2 — Магiчна атака");
    Console.WriteLine("3 — Атака луком");
    Console.WriteLine("4 — Захист");
    Console.WriteLine("0 — Вихiд");

    var input = Console.ReadLine();

    if (input == "0")
    {
        Console.WriteLine("Гра завершена.");
        break;
    }

    switch (input)
    {
        case "1":
            hero.SetStrategy(new SwordAttack());
            break;
        case "2":
            hero.SetStrategy(new MagicAttack());
            break;
        case "3":
            hero.SetStrategy(new BowAttack());
            break;
        case "4":
            hero.SetStrategy(new Defense());
            break;
        default:
            Console.WriteLine("Невiрний вибір, спробуйте ще раз.");
            continue;
    }

    hero.Attack();
}

interface IAttackStrategy
{
    void Attack();
}

class SwordAttack : IAttackStrategy
{
    public void Attack() => Console.WriteLine("Атака мечем!");
}

class MagicAttack : IAttackStrategy
{
    public void Attack() => Console.WriteLine("Магiчна атака!");
}

class BowAttack : IAttackStrategy
{
    public void Attack() => Console.WriteLine("Атака луком!");
}

class Defense : IAttackStrategy
{
    public void Attack() => Console.WriteLine("Захист!");
}

class Character
{
    private IAttackStrategy _strategy;

    public void SetStrategy(IAttackStrategy strategy) => _strategy = strategy;
    public void Attack() => _strategy.Attack();
}