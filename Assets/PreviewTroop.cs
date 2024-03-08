using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewTroop : MonoBehaviour
{
    public SpriteRenderer graphic;

    public TroopData data;

    Field field;

    InspectionWindow inspectionWindow;

    public void Initialize(TroopData troop, Field field, InspectionWindow inspectionWindow)
    {
        this.field = field;
        this.data = troop;
        this.inspectionWindow = inspectionWindow;

        graphic.sprite = troop.image;
    }

    public void OnMouseDown()
    {        
        inspectionWindow.UpdateWindow(this);
        inspectionWindow.SwitchToSelf();
    }

    public void OnDestroy()
    {
        field.placedTroops.Remove(this);
    }
}
