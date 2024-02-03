using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    TroopPlacer[] troopPlacers;

    TroopPlacer selectedPlacer = null;

    public void Start()
    {
        troopPlacers = GetComponentsInChildren<TroopPlacer>();

        for (int i = 0; i < troopPlacers.Length; i++)
        {
            troopPlacers[i].selectionManager = this;
        }
    }

    public void SelectPlacer(TroopPlacer placer)
    {
        selectedPlacer = placer;

        for (int i = 0; i < troopPlacers.Length; i++)
        {
            if(troopPlacers[i] == placer)
            {
                troopPlacers[i].Select();
            }
            else
            {
                troopPlacers[i].Deselect();
            }
        }
    }

    public void ClearSelection()
    {
        selectedPlacer = null;
    }
}
