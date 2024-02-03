using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TroopMovement))]
[RequireComponent(typeof(Troop))]
public class MeleeTroop : MonoBehaviour
{
    [Header("Note: Target type must be 'Troop'!")]

    public float attackDistance = 1f;

    public float attackTime = 1f;

    public GameObject attackIndicator;

    float attackTimer;

    TroopMovement troopMovement;

    Troop troop;

    // Start is called before the first frame update
    void Start()
    {
        troopMovement = GetComponent<TroopMovement>();
        troop = GetComponent<Troop>();
        attackTimer = Random.Range(0f, attackTime);
    }

    // Update is called once per frame
    void Update()
    {
        Troop target = troopMovement.targetTroop;

        if (target == null) return;

        if(Vector2.Distance(target.transform.position, transform.position) < attackDistance)
        {
            attackTimer -= Time.deltaTime;

            if(attackTimer < 0f)
            {
                attackTimer += attackTime;

                troop.Attack(target);

                Quaternion indicatorRotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - transform.position) * Quaternion.Euler(0, 0, 90f);
                Instantiate(attackIndicator, transform.position, indicatorRotation);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
