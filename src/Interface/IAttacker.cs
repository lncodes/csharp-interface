namespace Lncodes.Example.Interface;

public interface IAttacker
{
    int AttackDamage { get; }

    /// <summary>
    /// Executes an attack on another creature.
    /// </summary>
    void Attack();
}