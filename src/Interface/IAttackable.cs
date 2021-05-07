namespace Lncodes.Example.Interface
{
    public interface IAttackable
    {
        /// <value>Gets the attack damage value</value>
        int AttackDamage { get; }

        /// <summary>
        /// Method To Attack
        /// </summary>
        void Attack();
    }
}