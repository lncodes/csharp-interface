using System;

namespace Lncodes.Example.Interface
{
    public class Program
    {
        static void Main()
        {
            var attackableCreature = RandomAttackableCreature();
            var damageableCreature = RandomDamageableCreature();

            // Prevent creature from attacking their species
            while (damageableCreature.GetType().Equals(attackableCreature.GetType()))
                damageableCreature = RandomDamageableCreature();

            attackableCreature.Attack();
            damageableCreature.TakeDamage(attackableCreature.AttackDamage);
        }

        /// <summary>
        /// Method for random damageable creature
        /// </summary>
        /// <returns cref="IDamageable"></returns>
        /// <exception cref="Exception">Thrown when random value > 2</exception>
        private static IDamageable RandomDamageableCreature()
        {
            switch (new Random().Next(3))
            {
                case 0:
                    return new PlayerController();
                case 1:
                    return new EnemyController();
                case 2:
                    return new NpcController();
                default:
                    throw new Exception("Error to random damageable creature");
            }
        }

        /// <summary>
        /// Method for random attackable creature
        /// </summary>
        /// <returns cref="IAttackable"></returns>
        /// <exception cref="Exception">Thrown when random value > 1</exception>
        private static IAttackable RandomAttackableCreature()
        {
            switch (new Random().Next(2))
            {
                case 0:
                    return new PlayerController();
                case 1:
                    return new EnemyController();
                default:
                    throw new Exception("Error to random attackable creature");
            }
        }
    }
}