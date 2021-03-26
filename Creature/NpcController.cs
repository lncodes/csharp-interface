using System;

namespace Lncodes.Example.Interface
{
    public sealed class NpcController : IDamageable
    {
        public event Action OnHealthRunsOut;

        ///<inheritdoc cref="IDamageable.Health"/>
        public int Health { get; private set; } = 40;

        ///<inheritdoc cref="IDamageable.TakeDamage(int)"/>
        public void TakeDamage(int amountOfDamage)
        {
            Health -= amountOfDamage;
            if (Health == 0) OnHealthRunsOut();
            Console.WriteLine($"Current NPC health = {Health}");
        }
    }
}