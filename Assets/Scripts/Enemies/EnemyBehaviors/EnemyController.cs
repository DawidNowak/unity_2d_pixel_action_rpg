public class EnemyController : LivingObject
{
    protected MovingStrategy movingStrategy;

    protected override void Start()
    {
        base.Start();

        movingStrategy?.Start();
    }

    void Update()
    {
        movingStrategy?.Update();
    }
}
