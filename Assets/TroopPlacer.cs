using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroopPlacer : MonoBehaviour
{
    public bool selected = false;

    public Image image;

    [HideInInspector]
    public SelectionManager selectionManager;

    public void OnSelect()
    {
        selected = !selected;
        image.color = selected ? Color.green : Color.white;
    }

    public void Select()
    {
        selected = true;
    }

    public void Deselect()
    {
        selected = false;
    }
}
