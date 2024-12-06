using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPersonDetector : PersonDetector
{
    public BlinkingBehaviour blinkingBehaviour;
    public MeshRenderer meshRenderer;
    private bool isOnCached;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectorOn = !blinkingBehaviour.IsBlinking();
        if (isOnCached != detectorOn)
        {
            isOnCached = detectorOn;
            meshRenderer.enabled = isOnCached;
        }
    }
}
