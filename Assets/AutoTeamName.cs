using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoTeamName : MonoBehaviour
{
    TMP_InputField inputField;

    string[] adjectives = new string[] { "adventurous", "blue", "breakable", "clever", "confused", "dangerous", "difficult", "handsome", "innocent", "magnificent", "tough", "zealous" };
    string[] nouns = new string[] { "feathers", "tweezers", "balloons", "bats", "hamsters", "giraffes", "needles", "puddles", "pencils" };

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.text = string.Format("The {0} {1}", adjectives[Random.Range(0, adjectives.Length)], nouns[Random.Range(0, nouns.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
