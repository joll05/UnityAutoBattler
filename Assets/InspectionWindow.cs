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

    public CurrencyManager currencyManager;

    PreviewTroop currentTroop;

    public void UpdateWindow(PreviewTroop troop)
    {
        currentTroop = troop;

        nameText.text = troop.data.Name;
        healthText.text = troop.data.health.ToString();
        damageText.text = troop.data.damage.ToString();
        troopImage.sprite = troop.data.image;
    }

    public void SellTroop()
    {
        currencyManager.AddFunds(currentTroop.data.cost);
        
        Destroy(currentTroop.gameObject);

        DisplayWindow(false);
    }
}
