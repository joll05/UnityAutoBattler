using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    public float destroyTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(gameObject);
    }
}
