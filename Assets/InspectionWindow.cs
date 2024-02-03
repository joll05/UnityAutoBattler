using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InspectionWindow : UIWindow
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;
    public Image troopImage;

    public void UpdateWindow(Troop troop)
    {
        nameText.text = troop.data.Name;
        healthText.text = troop.health.ToString();
        damageText.text = troop.damage.ToString();
        troopImage.sprite = troop.data.image;
    }
}
