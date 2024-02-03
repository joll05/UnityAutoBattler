using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Troop))]
[RequireComponent(typeof(Rigidbody2D))]
public class TroopMovement : MonoBehaviour
{    
    public float movementForce = 3f;

    public virtual TargetType targetType => TargetType.Troop;
    
    [HideInInspector]
    public Troop targetTroop;

    [HideInInspector]
    public Vector2 targetPosition;
    
    public Vector2 target
    {
        get
        {
            switch(targetType)
            {
                case TargetType.Position:
                    return targetPosition;
                case TargetType.Troop:
                    return targetTroop != null ? targetTroop.transform.position : transform.position;
            }

            return Vector2.zero;
        }
    }

    [HideInInspector]
    public Troop self;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Troop>();
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual Troop GetTroopTarget()
    {
        return BattleManager.instance.FindClosestTroop(transform.position, (self.team + 1) % 2);
    }

    public virtual Vector2 GetVector2Target()
    {
        Troop troop = GetTroopTarget();
        return troop != null ? troop.transform.position : transform.position;
    }

    void UpdateTarget()
    {
        if(targetType == TargetType.Position)
        {
            targetPosition = GetVector2Target();
        }
        else if(targetType == TargetType.Troop)
        {
            targetTroop = GetTroopTarget();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTarget();

        Vector2 direction = (target - (Vector2)transform.position).normalized;

        rb.AddForce(direction * movementForce);

        Debug.DrawLine(transform.position, target);
    }
}

public enum TargetType
{
    Troop,
    Position
}
