using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Team Data")]
public class TeamData : ScriptableObject
{
    public List<TroopPlacementData> troops;
}

[System.Serializable]
public struct TroopPlacementData
{
    public TroopData troop;
    public Vector2 position;
}
