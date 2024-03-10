using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float speed = 1f;

    public int damage = 5;

    int team;
    
    Rigidbody2D rb;

    public void ProjectileInit(Vector2 startDirection, int team)
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = startDirection * speed;

        this.team = team;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Troop collisionTroop = collision.GetComponentInParent<Troop>();

        if (collisionTroop != null && collisionTroop.team != team)
        {
            collisionTroop.Hurt(damage);
            Destroy(gameObject);
        }
    }
}
