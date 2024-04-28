using System.Collections.Generic;

[System.Serializable]
public class TeamListData
{
    public List<TeamListDataItem> teams = new List<TeamListDataItem>();
}

[System.Serializable]
public class TeamListDataItem
{
    public int id = -1;
    public string username = "";
    public string teamname = "";
}