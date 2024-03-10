using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentManager : MonoBehaviour
{    
    public TeamData[] opponentTeams;

    // Start is called before the first frame update
    void Start()
    {
        TeamData selectedOpponent = opponentTeams[Random.Range(0, opponentTeams.Length)];

        // Temporary, allows me to test it
        BattleManager.instance.SpawnTeams(GameManager.instance.userTeam, selectedOpponent);
    }
}
