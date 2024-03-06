using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string textFormat;

    public void UpdateText(int amount)
    {
        text.text = string.Format(textFormat, amount);
    }
}
