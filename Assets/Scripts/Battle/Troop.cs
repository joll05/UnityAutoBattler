using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour
{
    public TroopData data;

    public int health;

    public bool IsDead
    {
        get => (health <= 0);
    }

    public int damage;

    public GameObject enemyCollider;

    //[HideInInspector]
    public int team = 0;

    public const int teamLayers = 20;


    // Start is called before the first frame update
    void Start()
    {
        enemyCollider.layer = teamLayers + team;
    }

    public void Attack(Troop other)
    {
        other.Hurt(damage);
    }

    public void Hurt(int damage)
    {
        health -= damage;

        if(IsDead)
        {
            gameObject.SetActive(false);
        }
    }
}
