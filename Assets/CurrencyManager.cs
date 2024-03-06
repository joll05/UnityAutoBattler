using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int currentMoney = 500;

    public CurrencyDisplay currencyDisplay;

    public void Start()
    {
        currencyDisplay.UpdateText(currentMoney);
    }

    public bool TrySpendMoney(int amount)
    {
        if (currentMoney < amount)
        {
            return false;
        }

        currentMoney -= amount;
        currencyDisplay.UpdateText(currentMoney);

        return true;
    }

    public void AddFunds(int amount)
    {
        currentMoney += amount;
        currencyDisplay.UpdateText(currentMoney);
    }
}
