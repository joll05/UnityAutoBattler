using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UploadPanel : MonoBehaviour
{
    public TMP_InputField teamNameInput;
    public TMP_InputField userNameInput;

    public Button submitButton;

    public Field field;

    public bool ValidateInput(string userName, string teamName)
    {
        if (userName.Trim() == "") return false;
        if (teamName.Trim() == "") return false;

        return true;
    }
    
    public void OnUpdate()
    {
        submitButton.interactable = ValidateInput(userNameInput.text, teamNameInput.text);
    }

    public void OnSubmit()
    {
        string teamName = teamNameInput.text.Trim();
        string userName = userNameInput.text.Trim();

        if (teamName == "" || userName == "") return;

        TeamData team = field.CreateTeamData();

        StartCoroutine(GameManager.instance.UploadTeamData(team, userName, teamName));
    }
}
