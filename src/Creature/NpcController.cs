using System;

namespace Lncodes.Example.Interface;

public sealed class NpcController : IDamageable
{
    public event Action OnHealthRunsOut;
    public int Health { get; private set; } = 40;

    /// <summary>
    /// Initializes a new instance of the <see cref="NpcController"/> class.
    /// </summary>
    public NpcController() =>
        OnHealthRunsOut += () => Console.WriteLine("NPC is defeated");

    ///<inheritdoc cref="IDamageable.TakeDamage(int)"/>
    public void TakeDamage(int amountOfDamage)
    {
        Health -= amountOfDamage;
        Console.WriteLine($"NPC's remaining health: {Health}");
        Console.WriteLine();
        if (Health <= 0) OnHealthRunsOut();
    }
}