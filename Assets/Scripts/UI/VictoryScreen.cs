using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    public TextMeshProUGUI text;

    public string winningText = "Your team won";
    public string losingText = "Your team lost";

    public void ShowVictoryScreen(int winningTeam)
    {
        gameObject.SetActive(true);

        if(winningTeam == 0)
        {
            text.text = winningText;
        }
        else
        {
            text.text = losingText;
        }
    }
}
