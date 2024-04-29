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

    public TextMeshProUGUI statusText;

    public Field field;

    bool isUploading = false;

    public bool ValidateInput(string userName, string teamName)
    {
        if (userName.Trim() == "") return false;
        if (teamName.Trim() == "") return false;

        return true;
    }
    
    public void OnUpdate()
    {
        if(isUploading) return;

        submitButton.interactable = ValidateInput(userNameInput.text, teamNameInput.text);
    }

    public void OnTextareaSelect(string text)
    {
        TouchScreenKeyboard.Open(text);
        Debug.Log("test");
    }

    public void OnSubmit()
    {
        string teamName = teamNameInput.text.Trim();
        string userName = userNameInput.text.Trim();

        if (teamName == "" || userName == "") return;

        TeamData team = field.CreateTeamData();

        StartCoroutine(GameManager.instance.UploadTeamData(team, userName, teamName, OnUploadComplete));

        isUploading = true;
        submitButton.interactable = false;
        statusText.text = "Uploading...";
    }

    public void OnUploadComplete(bool success)
    {
        statusText.text = success ? "Team uploaded" : "Upload failed";
        isUploading = false;
        OnUpdate();
    }
}
