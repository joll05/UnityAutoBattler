using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    
    public List<BattleTeam> teams;

    public GameObject enemyArmy;

    public bool battleActive = false;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void RegisterTroop(Troop troop, int team)
    {
        teams[team].troops.Add(troop);
    }

    public Troop FindClosestTroop(Vector2 point, int team)
    {
        List<Troop> troopList = teams[team].troops;

        float minDistance = Mathf.Infinity;
        Troop closestTroop = null;

        for (int i = 0; i < troopList.Count; i++)
        {
            Troop troop = troopList[i];

            if (troop.IsDead) continue;

            float distance = Vector2.Distance(troop.transform.position, point);

            if(distance < minDistance)
            {
                closestTroop = troop;
                minDistance = distance;
            }
        }

        return closestTroop;
    }

    public void StartBattle()
    {
        SpawnEnemyArmy();
        battleActive = true;
    }

    void SpawnEnemyArmy()
    {
        // Temporary
        //enemyArmy.SetActive(true);
    }
}

[System.Serializable]
public class BattleTeam
{
    public int team;
    public List<Troop> troops;
}
