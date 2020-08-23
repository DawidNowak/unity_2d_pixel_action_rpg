using System.Linq;
using UnityEngine;
using static Assets.Scripts.Utils.Enums;

public class ChasingStrategy : MovingStrategy
{
    public float playerDetectionRange = 100f;

    private float searchDelay = 1f;
    private float nextSearch = 0f;

    public static ChasingStrategy CreateComponent(GameObject where, float playerDetectionRange = 5f, float acceptableDistanceFromPlayer = 1f, float searchDelay = 1f)
    {
        ChasingStrategy strategy = where.AddComponent<ChasingStrategy>();
        strategy.playerDetectionRange = playerDetectionRange;
        strategy.acceptableDistanceFromTarget = acceptableDistanceFromPlayer;
        strategy.searchDelay = searchDelay;
        strategy.Start();
        return strategy;
    }

    public override void Start()
    {
        nextSearch = Time.time + 0.5f;
        base.Start();
    }

    public override void Update()
    {
        switch (state)
        {
            case WalkingState.Standing:
            default:
                ProcessStance();
                break;
            case WalkingState.Walking:
                break;
        }

        base.Update();
    }

    private void ProcessStance()
    {
        if (Time.time < nextSearch)
            return;

        var target = SearchForTarget();
        if (target != null)
        {
            Move(target.transform.position);
        }
    }

    private Collider2D SearchForTarget()
    {
        nextSearch = Time.time + searchDelay;
        var player = Physics2D.OverlapCircleAll(transform.position, playerDetectionRange, LayerMask.GetMask("Player"))
            .SingleOrDefault();

        return player;
    }
}
