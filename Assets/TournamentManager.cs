using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentManager : MonoBehaviour
{
    public List<TeamData> teams = new List<TeamData>();

    // Start is called before the first frame update
    void Start()
    {
        teams.Add(GameManager.instance.userTeam);

        // Temporary, allows me to test it
        BattleManager.instance.SpawnTeams(teams[teams.Count - 1], teams[0]);
    }
}
