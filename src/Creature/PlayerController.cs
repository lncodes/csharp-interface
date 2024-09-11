using System;

namespace Lncodes.Example.Interface;

public sealed class PlayerController : IDamageable, IAttacker
{
    public event Action OnHealthRunsOut;
    public int Health { get; private set; } = 80;
    public int AttackDamage { get; } = 10;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerController"/> class.
    /// </summary>
    public PlayerController() =>
        OnHealthRunsOut += () => Console.WriteLine("Player is defeated");

    ///<inheritdoc cref="IAttacker.Attack()"/>
    public void Attack() =>
        Console.WriteLine("The player's attack hit");

    ///<inheritdoc cref="IDamageable.TakeDamage(int)"/>
    public void TakeDamage(int amountOfDamage)
    {
        Health -= amountOfDamage;
        Console.WriteLine($"Player's remaining health: {Health}");
        Console.WriteLine();
        if (Health <= 0) OnHealthRunsOut();
    }
}