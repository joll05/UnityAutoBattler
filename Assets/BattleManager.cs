using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    
    public List<BattleTeam> teams;

    public Transform homeTeamParent;
    public Transform awayTeamParent;

    public bool battleActive = false;

    public static bool BattleActive => (instance != null) && instance.battleActive;

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

    public void SpawnTeams(TeamData homeTeam, TeamData awayTeam)
    {
        teams.Clear();

        SpawnTeam(homeTeam, homeTeamParent);
        SpawnTeam(awayTeam, awayTeamParent);
    }

    public void SpawnTeam(TeamData team, Transform parent)
    {
        BattleTeam battleTeam = new BattleTeam();
        battleTeam.team = teams.Count;

        foreach (TroopPlacementData troop in team.troops)
        {
            GameObject instance = Instantiate(troop.troop.prefab, parent.TransformPoint(troop.position), Quaternion.identity, parent);
            Troop troopInstance = instance.GetComponent<Troop>();
            troopInstance.team = teams.Count;
            battleTeam.troops.Add(troopInstance);
        }

        teams.Add(battleTeam);
    }
}

[System.Serializable]
public class BattleTeam
{
    public int team = -1;
    public List<Troop> troops = new List<Troop>();
}
