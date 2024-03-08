using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewTroop : MonoBehaviour
{
    public SpriteRenderer graphic;

    public TroopData data;

    InspectionWindow inspectionWindow;

    public void Initialize(TroopData troop, InspectionWindow inspectionWindow)
    {
        this.data = troop;
        this.inspectionWindow = inspectionWindow;

        graphic.sprite = troop.image;
    }

    public void OnMouseDown()
    {        
        inspectionWindow.UpdateWindow(this);
        inspectionWindow.SwitchToSelf();
    }
}
