using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopButton : MonoBehaviour
{
    public TroopData troop;

    public Field field;

    public void OnClick()
    {
        field.BuyTroop(troop);
    }
}
