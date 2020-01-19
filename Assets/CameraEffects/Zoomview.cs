using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomview : MonoBehaviour
{
    public float zoomIntensity;
    public Camera camera;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(camera.fieldOfView);
        camera.fieldOfView = 60.0f + rb.velocity.magnitude * zoomIntensity;
    }
}
