using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    const int battleScene = 1;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [HideInInspector]
    public TeamData userTeam;

    public void MoveToBattle(TeamData team)
    {
        this.userTeam = team;
        SceneManager.LoadScene(battleScene);
    }
}
