using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMovement : TroopMovement
{
    public override TargetType targetType => TargetType.Position;

    public float stoppingDistance = 5f;

    public override Vector2 GetVector2Target()
    {
        Vector2 baseTargetPos = base.GetVector2Target();

        if(Vector2.Distance(transform.position, baseTargetPos) < stoppingDistance)
        {
            return transform.position;
        }
        else
        {
            return baseTargetPos;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}
