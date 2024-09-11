using System;
using System.Security.Cryptography;

namespace Lncodes.Example.Interface;

public sealed class EnemyController : IDamageable, IAttacker
{
    public event Action OnHealthRunsOut;
    public int Health { get; private set; } = 60;
    public int AttackDamage { get; private set; } = 20;

    /// <summary>
    /// Initializes a new instance of the <see cref="EnemyController"/> class.
    /// </summary>
    public EnemyController() =>
        OnHealthRunsOut += () => Console.WriteLine("Enemy is defeated");

    ///<inheritdoc cref="IAttacker.Attack()"/>
    public void Attack()
    {
        const int accuracyRate = 70;
        if (RandomNumberGenerator.GetInt32(100) < accuracyRate)
        {
            AttackDamage = 20;
            Console.WriteLine("The enemy's attack hit");
        }
        else
        {
            AttackDamage = 0;
            Console.WriteLine("The enemy's attack miss");
        }
    }

    ///<inheritdoc cref="IDamageable.TakeDamage(int)"/>
    public void TakeDamage(int amountOfDamage)
    {
        Health -= amountOfDamage;
        Console.WriteLine($"Enemy's remaining health: {Health}");
        Console.WriteLine();
        if (Health <= 0) OnHealthRunsOut();
    }
}