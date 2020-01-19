using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    //Control names in Unity for Control keys (not hardcoded so keys are remappable)
    //[SerializeField] makes the field appear in the unity editor
    [SerializeField] private string boostKey = "space";

    Rigidbody RB;
    private float Speed = 800.0f;

    //Stores the rotation direction that the playerBall is facing
    private Quaternion FacingDirection;

    private float timeSinceBoost;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update FacingDirection
        FacingDirection = RB.rotation;

        //Apply forces on ball on up directional key press
        if(Input.GetKeyDown(boostKey) && timeSinceBoost > 3){
            RB.AddForce(FacingDirection * Vector3.forward * Speed, ForceMode.Force);
            timeSinceBoost = 0;
        }

        //Debug.Log(RB.velocity.magnitude);
        //if (RB.velocity.magnitude > 3)
        //{
        //    RB.velocity = RB.velocity * 0.97f;
        //}

        timeSinceBoost += Time.deltaTime;


    }
}
