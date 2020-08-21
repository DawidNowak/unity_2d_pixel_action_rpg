using UnityEngine;

public class EnemyController : LivingObject
{
    protected MovingStrategy movingStrategy;
    protected AttackingStrategy attackingStrategy;

    protected override void Start()
    {
        base.Start();

        if (movingStrategy != null)
        {
            movingStrategy.Start();
        };
    }

    protected virtual void Update()
    {
        if (movingStrategy != null)
        {
            movingStrategy.Update();
        };
    }
}
