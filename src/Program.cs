using System;
using System.Security.Cryptography;

namespace Lncodes.Example.Interface;

internal static class Program
{
    /// <summary>
    /// Main entry point of the program
    /// </summary>
    private static void Main()
    {
        const int attackerCreatureTypesCount = 2;
        const int damageableCreatureTypesCount = 3;

        // Create random attacker and damageable creatures
        var attackerCreature = CreateAttackerCreatureById(GetRandomCreatureTypeId(attackerCreatureTypesCount));
        var damageableCreature = CreateDamageableCreatureById(GetRandomCreatureTypeId(damageableCreatureTypesCount));

        // Ensure the damageable creature is not of the same type as the attacker creature
        while (damageableCreature.GetType() == attackerCreature.GetType())
            damageableCreature = CreateDamageableCreatureById(GetRandomCreatureTypeId(damageableCreatureTypesCount));

        // Simulate combat until the damageable creature's health reaches 0
        while (damageableCreature.Health > 0)
        {
            attackerCreature.Attack();
            damageableCreature.TakeDamage(attackerCreature.AttackDamage);
        }
    }

    /// <summary>
    /// Creates a damageable creature based on the provided type ID
    /// </summary>
    /// <param name="damageableCreatureTypeId">Type ID of the damageable creature</param>
    /// <returns>An instance of a class implementing <see cref="IDamageable"/></returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the provided type ID is invalid</exception>
    private static IDamageable CreateDamageableCreatureById(int damageableCreatureTypeId) =>
        damageableCreatureTypeId switch
        {
            0 => new PlayerController(),
            1 => new EnemyController(),
            2 => new NpcController(),
            _ => throw new ArgumentOutOfRangeException(nameof(damageableCreatureTypeId)),
        };

    /// <summary>
    /// Creates an attacker creature based on the provided type ID
    /// </summary>
    /// <param name="attackerCreatureTypeId">Type ID of the attacker creature</param>
    /// <returns>An instance of a class implementing <see cref="IAttacker"/></returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the provided type ID is invalid</exception>
    private static IAttacker CreateAttackerCreatureById(int attackerCreatureTypeId) =>
         attackerCreatureTypeId switch
         {
             0 => new PlayerController(),
             1 => new EnemyController(),
             _ => throw new ArgumentOutOfRangeException(nameof(attackerCreatureTypeId)),
         };

    /// <summary>
    /// Gets a random creature type ID within the specified range
    /// </summary>
    /// <param name="amountOfCreatureTypes">Total number of creature types</param>
    /// <returns>A random integer representing the creature type ID</returns>
    private static int GetRandomCreatureTypeId(int amountOfCreatureTypes) =>
        RandomNumberGenerator.GetInt32(amountOfCreatureTypes);
}