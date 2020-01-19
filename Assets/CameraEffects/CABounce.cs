using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CABounce : MonoBehaviour
{
    private float CAIntensity;
    private ChromaticAberration ca;

    // Start is called before the first frame update
    void Start()
    {
        CAIntensity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CAIntensity < 0.0f)
        {
            CAIntensity -= 0.04f;
        }
        else
        {
            CAIntensity = 0.0f;
        }



        PostProcessVolume volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings<ChromaticAberration>(out ca);
        ca.intensity.value = CAIntensity;

    }

    public void Bounced()
    {
        CAIntensity = 1.0f;
    }
}
