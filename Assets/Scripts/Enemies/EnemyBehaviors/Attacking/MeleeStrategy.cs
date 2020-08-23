using UnityEngine;

public class MeleeStrategy : AttackingStrategy
{
    public static MeleeStrategy CreateComponent(GameObject where, Vector3 attackPoint, float weaponRange = 1f, float attackRate = 1f, int attackDamage = 1)
    {
        MeleeStrategy strategy = where.AddComponent<MeleeStrategy>();
        strategy.attackPoint = attackPoint;
        strategy.weaponRange = weaponRange;
        strategy.attackRate = attackRate;
        strategy.attackDamage = attackDamage;
        strategy.Start();
        return strategy;
    }

    public override void PerformAttack(Collider2D player)
    {
        player.GetComponent<LivingObject>().TakeDamage(attackDamage);
    }

    protected override Collider2D PlayerInRange()
    {
        return base.PlayerInRange();
    }
}
