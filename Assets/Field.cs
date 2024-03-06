using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Field : MonoBehaviour
{
    public PlacementIndicator placementIndicator;

    public Transform troopParent;

    public WindowManager windowManager;
    public UIWindow troopWindow;
    public InspectionWindow inspectionWindow;
    
    bool hasTarget = false;
    Vector2 targetPosition = Vector2.zero;

    Camera cam;

    List<Troop> placedTroops = new List<Troop>();

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    public void PlaceTroop(TroopData troop)
    {
        GameObject instance = Instantiate(troop.prefab, targetPosition, Quaternion.identity, troopParent);
        Troop troopScript = instance.GetComponent<Troop>();
        placedTroops.Add(troopScript);
        //BattleManager.instance.RegisterTroop(troopScript, 0);
        ClearTargetPosition();
        inspectionWindow.UpdateWindow(troopScript);
        inspectionWindow.SwitchToSelf();
    }

    public void SubmitTeam()
    {
        TeamData teamData = CreateTeamData();

        GameManager.instance.MoveToBattle(teamData);
    }

    public TeamData CreateTeamData()
    {
        TeamData result = ScriptableObject.CreateInstance<TeamData>();

        result.troops = new List<TroopPlacementData>(placedTroops.Count);

        for (int i = 0; i < placedTroops.Count; i++)
        {
            TroopPlacementData placementData = new TroopPlacementData();
            placementData.troop = placedTroops[i].data;
            placementData.position = transform.InverseTransformPoint(placedTroops[i].transform.position);

            result.troops.Add(placementData);
        }

        return result;
    }

    public void SetTargetPosition(Vector3 target)
    {
        hasTarget = true;
        targetPosition = target;
        placementIndicator.Place(targetPosition);
        troopWindow.SwitchToSelf();
    }

    public void ClearTargetPosition(bool clearWindow = true)
    {
        hasTarget = false;
        placementIndicator.Clear();
        
        if(clearWindow) windowManager.SwitchWindow(-1);
    }

    private void OnMouseUpAsButton()
    {
        SetTargetPosition(cam.ScreenToWorldPoint(Input.mousePosition));
    }
}
