using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InspectionWindow : UIWindow
{
    public TextMeshProUGUI nameText;
    public IconStat damageStat;
    public IconStat attackSpeedStat;
    public IconStat healthStat;
    public IconStat speedStat;
    public Image troopImage;

    public CurrencyManager currencyManager;

    PreviewTroop currentTroop;

    public void UpdateWindow(PreviewTroop troop)
    {
        currentTroop = troop;

        nameText.text = troop.data.Name;

        damageStat.SetStat(troop.data.damage);
        attackSpeedStat.SetStat(troop.data.attackSpeed);
        healthStat.SetStat(troop.data.health);
        speedStat.SetStat(troop.data.speed);

        troopImage.sprite = troop.data.image;
    }

    public void SellTroop()
    {
        currencyManager.AddFunds(currentTroop.data.cost);
        
        Destroy(currentTroop.gameObject);

        DisplayWindow(false);
    }
}
