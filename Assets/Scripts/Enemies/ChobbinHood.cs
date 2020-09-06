
using UnityEngine;

public class ChobbinHood : EnemyController
{
    protected override void Init()
    {
        statictics = new StatisticsSystem(5, 5, 10, 0);
        hpPercWhenFlee = 0f;
        expForKilling = 25;
        movingStrategy = WanderingStrategy.CreateComponent(gameObject, 2f);
        attackingStrategy = RangedProjectileStrategy.CreateComponent(gameObject, Vector3.up * 0.3f, attackRate: 0.5f);

        base.Init();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (health > 0)
        {
            if (!wasHit)
            {
                wasHit = true;
                Destroy(movingStrategy);
                movingStrategy = ChasingStrategy.CreateComponent(gameObject, playerDetectionRange: attackingStrategy.weaponRange + 2f, acceptableDistanceFromPlayer: attackingStrategy.weaponRange - 0.5f, searchDelay: 0.5f);
                movingStrategy.TargetReachedCallback += attackingStrategy.ProcessAttack;
            }

            if (NeedToFlee())
            {
                StartFleeing();
            }
        }
    }

    protected override void StartFleeing()
    {
        //TODO: IMPLEMENT
        base.StartFleeing();
    }
}
