
using UnityEngine;

public class Rabilion : EnemyController
{
    protected override void Init()
    {
        statictics = new StatisticsSystem(2, 2, 3);
        hpPercWhenFlee = 0.4f;
        expForKilling = 10;
        movingStrategy = WanderingStrategy.CreateComponent(gameObject);
        attackingStrategy = MeleeStrategy.CreateComponent(gameObject, Vector3.up * 0.45f, 0.5f, 0.5f);

        base.Init();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (statictics.HitPoints > 0)
        {
            if (!wasHit)
            {
                wasHit = true;
                Destroy(movingStrategy);

                movingStrategy = ChasingStrategy.CreateComponent(gameObject, acceptableDistanceFromPlayer: 0.7f, searchDelay: 0.5f);
                movingStrategy.TargetReachedCallback += attackingStrategy.ProcessAttack;
            }

            if (NeedToFlee())
            {
                StartFleeing();
            }
        }
    }
}
