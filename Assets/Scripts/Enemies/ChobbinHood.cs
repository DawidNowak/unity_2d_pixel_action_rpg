public class ChobbinHood : EnemyController
{
    protected override void Init()
    {
        maxHealth = 10;
        hpPercWhenFlee = 0f;
        //movingStrategy = WanderingStrategy.CreateComponent(gameObject, 40f, 0.5f);

        base.Init();
    }
}
