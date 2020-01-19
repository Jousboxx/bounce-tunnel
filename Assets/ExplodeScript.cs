using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    //Parameters
    public float MaxForce;
    public float MinForce;
    public float Radius;
    public float DestroyDelay = 5;

    public void Explode(){
        foreach(Transform t in transform){

            Rigidbody rb = t.GetComponent<Rigidbody>();

            //Apply explosion force
            if(rb != null){
                rb.AddExplosionForce(Random.Range(MinForce, MaxForce), transform.position, Radius);
            }

            Destroy(t.gameObject, DestroyDelay);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Explode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
