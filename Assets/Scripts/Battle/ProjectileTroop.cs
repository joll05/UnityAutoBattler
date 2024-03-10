using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangerMovement))]
public class ProjectileTroop : BattleScript
{
    public float attackTime = 1f;

    public float attackRadius = 4f;

    public Projectile projectilePrefab;

    float attackTimer = 0f;

    RangerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = Random.Range(0f, attackTime);

        movement = GetComponent<RangerMovement>();
    }

    // Update is called once per frame
    public override void BattleUpdate()
    {
        Troop target = movement.GetTroopTarget();

        if (target == null) return;

        if(Vector2.Distance(target.transform.position, transform.position) < attackRadius)
        {
            attackTimer -= Time.deltaTime;

            if(attackTimer <= 0f)
            {
                attackTimer += attackTime;

                Projectile projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                projectileInstance.ProjectileInit((target.transform.position - transform.position).normalized, movement.self.team);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue + Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
