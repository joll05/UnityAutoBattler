using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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

    [HideInInspector]
    public bool playerBattle = false;
    
    [HideInInspector]
    public TeamData userTeam2;

    public void MoveToBattle(TeamData team)
    {
        this.playerBattle = false;
        this.userTeam = team;
        SceneManager.LoadScene(battleScene);
    }
    
    public void MoveToBattle(TeamData team1, TeamData team2)
    {
        this.playerBattle = true;
        this.userTeam = team1;
        this.userTeam2 = team2;
        SceneManager.LoadScene(battleScene);
    }

    private System.Uri baseUri = new System.Uri("https://infuriating-release.000webhostapp.com/");

    public IEnumerator UploadTeamData(TeamData team, string userName, string teamName)
    {
        System.Uri uri = new System.Uri(baseUri, "upload.php");

        WWWForm data = new WWWForm();
        data.AddField("team", team.ToJson());
        data.AddField("username", userName);
        data.AddField("teamname", teamName);

        UnityWebRequest request = UnityWebRequest.Post(uri, data);
        yield return request.SendWebRequest();

        Debug.Log(request.result);
        Debug.Log(request.downloadHandler.text);
        Debug.Log(request.url);

        request.Dispose();
    }

    public delegate void TeamListCallback(TeamListData data);
    
    public IEnumerator GetTeamList(TeamListCallback callback)
    {
        System.Uri uri = new System.Uri(baseUri, "list.php");

        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        callback.Invoke(JsonUtility.FromJson<TeamListData>(request.downloadHandler.text));
    }

    public delegate void TeamDataCallback(TeamData data);
    
    public IEnumerator DownloadTeamData(int id, TeamDataCallback callback)
    {
        System.Uri uri = new System.Uri(baseUri, "download.php?id=" + id);

        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        TeamData teamData = TeamData.FromJson(request.downloadHandler.text);
        callback.Invoke(teamData);
    }
}
