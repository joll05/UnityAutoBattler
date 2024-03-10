using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconStat : MonoBehaviour
{
    public Image[] icons;

    public Color goodColor = Color.white;
    public Color badColor = new Color(1f, 1f, 1f, 0.5f);

    public void SetStat(int amount)
    {
        int count = Mathf.Min(icons.Length, amount);

        for (int i = 0; i < count; i++)
        {
            icons[i].color = goodColor;
        }

        for (int i = count; i < icons.Length; i++)
        {
            icons[i].color = badColor;
        }
    }
}
