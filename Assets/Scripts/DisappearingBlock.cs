using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBlock : MonoBehaviour
{
    [SerializeField] private float disappearTime;
    private float disappearTimer = 0f;
    public bool isDisappearing = false;

    private Renderer blockRenderer;

    void Start()
    {
        blockRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isDisappearing)
        {
            disappearTimer += Time.deltaTime;
            var color = blockRenderer.material.color;
            color.a = Mathf.Lerp(1f, 0f, disappearTimer / disappearTime);
            blockRenderer.material.color = color;
            if (disappearTimer >= disappearTime)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
