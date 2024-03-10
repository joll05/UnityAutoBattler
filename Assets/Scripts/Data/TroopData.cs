using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TroopData : ScriptableObject
{
    public string Name;

    public GameObject prefab;

    public Sprite image;

    public int health;
    public int damage;
    public int speed;
    public int attackSpeed;

    public int cost = 0;
}
