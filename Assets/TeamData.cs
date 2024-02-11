using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamData
{
    public List<TroopPlacementData> troops;
}

public class TroopPlacementData
{
    public TroopData troop;
    public Vector2 position;
}
