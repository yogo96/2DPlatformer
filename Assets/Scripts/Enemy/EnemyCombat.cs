public class EnemyCombat : Combat<Player>
{
    protected override void AttackTarget()
    {
        _target.TakeDamage(_attackDamage);
    }
    
}