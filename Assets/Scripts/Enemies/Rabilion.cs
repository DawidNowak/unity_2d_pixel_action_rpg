
public class Rabilion : EnemyController
{
    private bool wasHit = false;

    protected override void Init()
    {
        maxHealth = 5;
        hpPercWhenFlee = 0.4f;
        movingStrategy = WanderingStrategy.CreateComponent(gameObject, 20f);
        attackingStrategy = MeleeStrategy.CreateComponent(gameObject, attackRate: 0.5f);

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
                movingStrategy = ChasingStrategy.CreateComponent(gameObject, acceptableDistanceFromPlayer: 19f, searchDelay: 0.5f);
                movingStrategy.TargetReachedCallback += attackingStrategy.ProcessAttack;
            }

            if (NeedToFlee())
            {
                StartFleeing();
            }
        }
    }

    private void StartFleeing()
    {
        Destroy(movingStrategy);
        movingStrategy = FleeingStrategy.CreateComponent(gameObject);
    }
}
