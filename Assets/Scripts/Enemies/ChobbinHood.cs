public class ChobbinHood : EnemyController
{
    protected override void Init()
    {
        maxHealth = 10;
        hpPercWhenFlee = 0f;
        movingStrategy = WanderingStrategy.CreateComponent(gameObject, 40f, 0.25f);
        attackingStrategy = RangedProjectiileStrategy.CreateComponent(gameObject, attackRate: 0.5f);

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
                movingStrategy = ChasingStrategy.CreateComponent(gameObject, playerDetectionRange: attackingStrategy.weaponRange + 60f, acceptableDistanceFromPlayer: attackingStrategy.weaponRange, searchDelay: 0.5f);
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
