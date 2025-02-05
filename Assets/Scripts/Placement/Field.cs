using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Field : MonoBehaviour
{
    public PlacementIndicator placementIndicator;

    public GameObject previewTroopPrefab;

    public Transform troopParent;

    public WindowManager windowManager;
    public UIWindow troopWindow;
    public InspectionWindow inspectionWindow;

    public CurrencyManager currencyManager;
    
    bool hasTarget = false;
    Vector2 targetPosition = Vector2.zero;

    Camera cam;

    [HideInInspector]
    public List<PreviewTroop> placedTroops = new List<PreviewTroop>();

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        if(GameManager.instance.userTeam != null)
        {
            List<TroopPlacementData> troops = GameManager.instance.userTeam.troops;

            for (int i = 0; i < troops.Count; i++)
            {
                SetTargetPosition(troopParent.TransformPoint(troops[i].position));
                BuyTroop(troops[i].troop);
            }

            windowManager.SwitchWindow(null);
        }
    }

    public void BuyTroop(TroopData troop)
    {
        bool success = currencyManager.TrySpendMoney(troop.cost);

        if(success)
        {
            PlaceTroop(troop);
        }
    }

    public void PlaceTroop(TroopData troop)
    {
        GameObject instance = Instantiate(previewTroopPrefab, targetPosition, Quaternion.identity, troopParent);
        PreviewTroop troopScript = instance.GetComponent<PreviewTroop>();
        troopScript.Initialize(troop, this, inspectionWindow);
        placedTroops.Add(troopScript);
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
        placementData.position = troopParent.InverseTransformPoint(placedTroops[i].transform.position);

        result.troops.Add(placementData);
    }

    return result;
}

#if UNITY_EDITOR
    [ContextMenu("Save Team Data")]
    void Util_SaveTeamData()
    {
        TeamData data = CreateTeamData();
        System.DateTime now = System.DateTime.Now;
        string suffix = now.Hour.ToString("00") + now.Minute.ToString("00") + now.Second.ToString("00");
        AssetDatabase.CreateAsset(data, string.Format("Assets/Teams/Team {0}.asset", suffix));
    }
#endif

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
