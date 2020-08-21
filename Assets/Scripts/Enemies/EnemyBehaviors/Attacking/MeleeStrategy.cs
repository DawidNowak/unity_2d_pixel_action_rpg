using UnityEngine;

public class MeleeStrategy : AttackingStrategy
{
    public static MeleeStrategy CreateComponent(GameObject where, float weaponRange = 20f, float attackRate = 2f, int attackDamage = 1)
    {
        MeleeStrategy strategy = where.AddComponent<MeleeStrategy>();
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
}
