using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public UIWindow[] windows;

    UIWindow currentWindow = null;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].manager = this;
            windows[i].DisplayWindow(false);
        }   
    }

    public void SwitchWindow(int index)
    {
        if (currentWindow != null) currentWindow.DisplayWindow(false);

        if (index >= 0)
        {
            currentWindow = windows[index];
            currentWindow.DisplayWindow(true);
        }
        else
        {
            currentWindow = null;
        }
    }

    public void SwitchWindow(UIWindow window)
    {
        if (currentWindow != null) currentWindow.DisplayWindow(false);

        currentWindow = window;
        if (currentWindow != null) currentWindow.DisplayWindow(true);
    }
}
