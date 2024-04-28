using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListManager : MonoBehaviour
{
    public Transform listItemParent;

    public GameObject listItem;

    public TeamListData TeamListData;

    public void DoUpdate()
    {
        StartCoroutine(GameManager.instance.GetTeamList(OnListDownload));
    }

    public void OnListDownload(TeamListData teamListData)
    {
        TeamListData = teamListData;

        for (int i = 0; i < listItemParent.childCount; i++)
        {
            Destroy(listItemParent.GetChild(0).gameObject);
        }

        for (int i = 0; i < teamListData.teams.Count; i++)
        {
            TeamListDataItem item = teamListData.teams[i];

            GameObject instance = Instantiate(listItem, listItemParent);

            instance.GetComponent<TeamListItem>().Initialize(item, this);
        }
    }

    bool itemSelected = false;
    int selectedItem = -1;
    
    public void SelectItem(int id)
    {
        if(!itemSelected)
        {
            itemSelected = true;
            selectedItem = id;
        }
        else
        {
            StartCoroutine(GameManager.instance.DownloadTeamData(id, OnTeamDownload));
            StartCoroutine(GameManager.instance.DownloadTeamData(selectedItem, OnTeamDownload));
        }
    }

    TeamData team1 = null;
    TeamData team2 = null;
    
    public void OnTeamDownload(TeamData teamData)
    {
        if (team1 == null) team1 = teamData;
        else GameManager.instance.MoveToBattle(team1, teamData);
    }

    public void DeselectItem()
    {
        itemSelected = false;
    }
}
