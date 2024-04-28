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

    public void MoveToBattle(TeamData team)
    {
        this.userTeam = team;
        SceneManager.LoadScene(battleScene);
    }

    private System.Uri baseUri = new System.Uri("http://localhost:90/mm/");

    public IEnumerator UploadTeamData(TeamData team, string userName, string teamName)
    {
        System.Uri uri = new System.Uri(baseUri, "upload.php");

        WWWForm data = new WWWForm();
        data.AddField("team", JsonUtility.ToJson(team));
        data.AddField("username", userName);
        data.AddField("teamname", teamName);

        UnityWebRequest request = UnityWebRequest.Post(uri, data);
        yield return request.SendWebRequest();

        Debug.Log(request.result);
        Debug.Log(request.downloadHandler.text);
        Debug.Log(request.url);

        request.Dispose();
    }
}
