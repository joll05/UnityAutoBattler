using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementIndicator : MonoBehaviour
{
    public GameObject graphic;

    private void Start()
    {
        Clear();
    }

    public void Place(Vector2 position)
    {
        transform.position = position;
        graphic.SetActive(true);
    }

    public void Clear()
    {
        graphic.SetActive(false);
    }
}
