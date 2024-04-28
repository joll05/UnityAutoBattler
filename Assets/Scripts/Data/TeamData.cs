using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Team Data")]
public class TeamData : ScriptableObject
{    
    public List<TroopPlacementData> troops;

    public string ToJson()
    {
        JSONTeamData JSONTeamData = new JSONTeamData();
        JSONTeamData.troops = new List<JSONPlacementData>();

        for (int i = 0; i < troops.Count; i++)
        {
            JSONTeamData.troops.Add(new JSONPlacementData(troops[i]));
        }
        
        return JsonUtility.ToJson(JSONTeamData);
    }

    public static TeamData FromJson(string json)
    {
        JSONTeamData JSONTeamData = JsonUtility.FromJson<JSONTeamData>(json);

        TeamData result = ScriptableObject.CreateInstance<TeamData>();
        result.troops = new List<TroopPlacementData>();

        for (int i = 0; i < JSONTeamData.troops.Count; i++)
        {
            TroopPlacementData troop = new TroopPlacementData();
            troop.troop = Resources.Load<TroopData>(JSONTeamData.troops[i].path);
            troop.position = JSONTeamData.troops[i].position;

            result.troops.Add(troop);
        }

        return result;
    }
}

[System.Serializable]
public struct TroopPlacementData
{
    public TroopData troop;
    public Vector2 position;
}

[System.Serializable]
public struct JSONTeamData
{
    public List<JSONPlacementData> troops;
}

[System.Serializable]
public struct JSONPlacementData
{
    public string path;
    public Vector2 position;

    public JSONPlacementData(TroopPlacementData data)
    {
        path = "Troops/" + data.troop.name;
        position = data.position;
    }
}
