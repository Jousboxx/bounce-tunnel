using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    //Control names in Unity for WASD
    [SerializeField] private string WKeyName = "Mouse Y";
    [SerializeField] private string AKeyName = "Mouse Y";
    [SerializeField] private string SKeyName = "Mouse Y";
    [SerializeField] private string DKeyName = "Mouse Y";

    Rigidbody RB;
    private float Speed = 20.0f;

    //Stores the rotation direction that the playerBall is facing
    private Quaternion FacingDirection;

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

        //Multiply the direction by a straight forward vector to convert the quanternion to a vector, then multiply by speed cause gotta go fast
        Vector3 ForceToAdd = FacingDirection * Vector3.forward * Speed;


        //Apply force on ball on up arrow press 
        //TODO change this to W
        if(Input.GetKey(KeyCode.UpArrow))
        {
            RB.AddForce(ForceToAdd, ForceMode.Force);
        }
    }
}
