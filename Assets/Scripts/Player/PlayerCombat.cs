public class PlayerCombat : Combat<Enemy>
{
    protected override void AttackTarget()
    {
        _target.TakeDamage(_attackDamage);
    }
}