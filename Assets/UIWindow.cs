using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [HideInInspector]
    public WindowManager manager;

    public void DisplayWinow(bool visible)
    {
        gameObject.SetActive(visible);
    }

    public void SwitchToSelf()
    {
        manager.SwitchWindow(this);
    }
}
