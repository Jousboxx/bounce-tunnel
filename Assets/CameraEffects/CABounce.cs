using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CABounce : MonoBehaviour
{
    private float CAIntensity;

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

        //Setting CA intensity here
    }

    public void Bounced()
    {
        CAIntensity = 1.0f;
    }
}
