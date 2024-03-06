using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [HideInInspector]
    public WindowManager manager;

    public void DisplayWindow(bool visible) // Misspelled, please refactor
    {
        gameObject.SetActive(visible);
    }

    public void SwitchToSelf()
    {
        manager.SwitchWindow(this);
    }
}
