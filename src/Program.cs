using System;
using System.Security.Cryptography;

namespace Lncodes.Example.Interface
{
    public class Program
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected Program() { }

        /// <summary>
        /// Main Program
        /// </summary>
        private static void Main()
        {
            var attackableCreature = CreateAttackableCreatureById(GetRandomAttackableCreatureTypeId());
            var damageableCreature = CreateDamageableCreatureById(GetRandomDamageableCreatureTypeId());

            // Prevent creature from attacking their species
            while (damageableCreature.GetType().Equals(attackableCreature.GetType()))
                damageableCreature = CreateDamageableCreatureById(GetRandomDamageableCreatureTypeId());

            attackableCreature.Attack();
            damageableCreature.TakeDamage(attackableCreature.AttackDamage);
        }

        /// <summary>
        /// Method for random damageable creature
        /// </summary>
        /// <param name="damageableCreatureTypeId"></param>
        /// <returns cref="IDamageable"></returns>
        /// <exception cref="Exception">Thrown when random value > 2</exception>
        private static IDamageable CreateDamageableCreatureById(int damageableCreatureTypeId)
        {
            switch (damageableCreatureTypeId)
            {
                case 0:
                    return new PlayerController();
                case 1:
                    return new EnemyController();
                case 2:
                    return new NpcController();
                default:
                    throw new ArgumentOutOfRangeException(nameof(damageableCreatureTypeId));
            }
        }

        /// <summary>
        /// Method for random attackable creature
        /// </summary>
        /// <param name="attackableCreatureTypeId"></param>
        /// <returns cref="IAttackable"></returns>
        /// <exception cref="Exception">Thrown when random value > 1</exception>
        private static IAttackable CreateAttackableCreatureById(int attackableCreatureTypeId)
        {
            switch (attackableCreatureTypeId)
            {
                case 0:
                    return new PlayerController();
                case 1:
                    return new EnemyController();
                default:
                    throw new ArgumentOutOfRangeException(nameof(attackableCreatureTypeId));
            }
        }

        /// <summary>
        /// Method to get random damageable creature id
        /// </summary>
        /// <returns cref=int></returns>
        private static int GetRandomDamageableCreatureTypeId()
        {
            var ammountOfDamageableCreatureTypes = 3;
            return RandomNumberGenerator.GetInt32(ammountOfDamageableCreatureTypes);
        }


        /// <summary>
        /// Method to get random attackable creature id
        /// </summary>
        /// <returns cref=int></returns>
        private static int GetRandomAttackableCreatureTypeId()
        {
            var ammountOfAttackableCreatureTypes = 2;
            return RandomNumberGenerator.GetInt32(ammountOfAttackableCreatureTypes);
        }
    }
}