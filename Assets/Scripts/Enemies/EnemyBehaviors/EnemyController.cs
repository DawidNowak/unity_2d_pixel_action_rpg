public class EnemyController : LivingObject
{
    protected MovingStrategy movingStrategy;

    protected override void Start()
    {
        base.Start();

        if (movingStrategy != null)
        {
            movingStrategy.Start();
        };
    }

    void Update()
    {
        if (movingStrategy != null)
        {
            movingStrategy.Update();
        };
    }
}
