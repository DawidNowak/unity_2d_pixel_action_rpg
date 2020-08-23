using System;
using UnityEngine;

public class RangedProjectiileStrategy : AttackingStrategy
{
    protected GameObject arrowPrefab;

    public static RangedProjectiileStrategy CreateComponent(GameObject where, float weaponRange = 120f, float attackRate = 1f, int attackDamage = 1)
    {
        RangedProjectiileStrategy strategy = where.AddComponent<RangedProjectiileStrategy>();
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
        attackPoint = transform;    //adjust by facing direction, for now it can be pivot point of enemy

        Shoot(player);
    }

    private void Shoot(Collider2D player)
    {
        var startPosition = attackPoint.position + Vector3.up * 10f;
        var targetPosition = player.gameObject.transform.position + Vector3.up * 10f;
        var direction = (targetPosition - startPosition).normalized;
        float sign = (player.gameObject.transform.position.y < startPosition.y) ? -1.0f : 1.0f;
        var angle = Vector2.Angle(Vector2.right, direction) * sign;
        Instantiate(arrowPrefab, startPosition, Quaternion.Euler(0f, 0f, angle - 90));
    }
}
