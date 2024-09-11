namespace Lncodes.Example.Interface;

public interface IDamageable
{
    int Health { get; }

    event System.Action OnHealthRunsOut;

    /// <summary>
    /// Applies damage to the entity.
    /// </summary>
    /// <param name="amountOfDamage">The amount of damage to apply.</param>
    void TakeDamage(int amountOfDamage);
}