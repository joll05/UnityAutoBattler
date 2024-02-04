using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class InteractionArea : MonoBehaviour
{
    public bool active = false;

    public float alphaSmoothTime = 0.5f;

    CanvasGroup canvasGroup;

    float smoothDampVelocity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        canvasGroup.interactable = active;
        canvasGroup.alpha = Mathf.SmoothDamp(canvasGroup.alpha, active ? 1f : 0f, ref smoothDampVelocity, alphaSmoothTime);
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }
}
