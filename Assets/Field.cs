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

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    public void PlaceTroop(TroopData troop)
    {
        GameObject troopObject = Instantiate(troop.prefab, targetPosition, Quaternion.identity, troopParent);
        Troop troopScript = troopObject.GetComponent<Troop>();
        ClearTargetPosition();
        inspectionWindow.UpdateWindow(troopScript);
        inspectionWindow.SwitchToSelf();
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
