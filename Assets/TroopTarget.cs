using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TroopTarget : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject troop;
    public Transform parent;

    GameObject instance;

    public void OnBeginDrag(PointerEventData eventData)
    {
        instance = Instantiate(troop, eventData.position, Quaternion.identity, parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        instance.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        instance = null;
    }
}
