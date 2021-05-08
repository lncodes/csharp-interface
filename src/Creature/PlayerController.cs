using System;
using System.Security.Cryptography;

namespace Lncodes.Example.Interface
{
    public sealed class PlayerController : IDamageable, IAttackable
    {
        public event Action OnHealthRunsOut;

        ///<inheritdoc cref="IDamageable.Health"/>
        public int Health { get; private set; } = 100;

        ///<inheritdoc cref="IAttackable.AttackDamage"/>
        public int AttackDamage { get; private set; } = 10;

        ///<inheritdoc cref="IAttackable.Attack()"/>
        public void Attack()
        {
            var accuracyRate = 50;
            if (RandomNumberGenerator.GetInt32(100) < accuracyRate)
                Console.WriteLine("The player has attacked");
            else
            {
                AttackDamage = 0;
                Console.WriteLine("Player attack failed");
            }
        }

        ///<inheritdoc cref="IDamageable.TakeDamage(int)"/>
        public void TakeDamage(int amountOfDamage)
        {
            Health -= amountOfDamage;
            if (Health == 0) OnHealthRunsOut();
            Console.WriteLine($"Current player health = {Health}");
        }
    }
}