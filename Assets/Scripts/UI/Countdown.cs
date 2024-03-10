using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public Animator[] texts;

    public BattleManager battleManager;

    public float startDelay = 0.5f;
    public float delay = 1f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].SetTrigger("Start");
            
            if(i < texts.Length - 1)
            {
                yield return new WaitForSeconds(delay);
            }
        }

        battleManager.battleActive = true;
    }
}
