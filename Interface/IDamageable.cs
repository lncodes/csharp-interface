namespace Lncodes.Example.Interface
{
    public interface IDamageable
    {
        /// <value>Gets the Health value</value>
        int Health { get; }

        event System.Action OnHealthRunsOut;

        /// <summary>
        /// Method For Take Damage
        /// </summary>
        /// <param name="amountDamage"></param>
        void TakeDamage(int amountDamage);
    }
}