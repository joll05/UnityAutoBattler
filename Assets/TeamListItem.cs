using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamListItem : MonoBehaviour
{
    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI teamnameText;

    public Color selectedColor = Color.blue;
    public Color deselectedColor = Color.white;

    public Image bgImage;

    ListManager manager;

    int id;

    bool selected = false;

    public void Initialize(TeamListDataItem item, ListManager manager)
    {
        usernameText.text = item.username;
        teamnameText.text = item.teamname;

        id = item.id;

        this.manager = manager;
    }

    public void OnClick()
    {
        selected = !selected;

        if(selected)
        {
            manager.SelectItem(id);
        }
        else
        {
            manager.DeselectItem();
        }

        bgImage.color = selected ? selectedColor : deselectedColor;
    }
}
