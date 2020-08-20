using System.Linq;
using UnityEngine;
using static Assets.Scripts.Utils.Enums;

public class Aggresive : MovingObject
{
    public Stance stance = Stance.Aggressive;
    public float playerDetectionRange = 100f;

    private float searchDelay = 1f;
    private float nextSearch = 0f;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
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
        if (stance == Stance.Defensive || Time.time < nextSearch)
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
