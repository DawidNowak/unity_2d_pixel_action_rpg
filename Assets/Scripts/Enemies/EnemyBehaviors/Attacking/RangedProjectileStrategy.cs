using UnityEngine;

public class RangedProjectileStrategy : AttackingStrategy
{
    protected GameObject arrowPrefab;

    public static RangedProjectileStrategy CreateComponent(GameObject where, Vector3 attackPoint, float weaponRange = 4f, float attackRate = 1f, int attackDamage = 1)
    {
        RangedProjectileStrategy strategy = where.AddComponent<RangedProjectileStrategy>();
        strategy.attackPoint = attackPoint;
        strategy.weaponRange = weaponRange;
        strategy.attackRate = attackRate;
        strategy.attackDamage = attackDamage;
        strategy.Start();

        return strategy;
    }

    protected override void Start()
    {
        arrowPrefab = (GameObject)Resources.Load("Prefabs/Common/Arrow");
        base.Start();
    }

    public override void PerformAttack(Collider2D player)
    {
        Shoot(player);
    }

    private void Shoot(Collider2D player)
    {
        var attackOrigin = transform.position + attackPoint;
        var targetPosition = player.gameObject.transform.position + Vector3.up * 0.3f;
        var direction = (targetPosition - attackOrigin).normalized;
        float sign = (player.gameObject.transform.position.y < attackOrigin.y) ? -1.0f : 1.0f;
        var angle = Vector2.Angle(Vector2.right, direction) * sign;
        Instantiate(arrowPrefab, attackOrigin, Quaternion.Euler(0f, 0f, angle - 90));
    }
}
