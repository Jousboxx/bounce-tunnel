using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    //Control names in Unity for Control keys (not hardcoded so keys are remappable)
    //[SerializeField] makes the field appear in the unity editor
    [SerializeField] private string ForwardKeyName = "w";
    [SerializeField] private string LeftKeyName = "a";
    [SerializeField] private string BackwardKeyName = "s";
    [SerializeField] private string RightKeyName = "d";
    [SerializeField] private string UpKeyName = "q";
    [SerializeField] private string DownKeyName = "e";
    [SerializeField] private string BrakeKeyName = "space";

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

        //Apply forces on ball on up directional key press
        if(Input.GetKey(ForwardKeyName))
        {
            RB.AddForce(FacingDirection * Vector3.forward * Speed, ForceMode.Force);
        }

        if(Input.GetKey(BackwardKeyName))
        {
            RB.AddForce(FacingDirection * Vector3.back * Speed, ForceMode.Force);
        }

        if(Input.GetKey(LeftKeyName))
        {
            RB.AddForce(FacingDirection * Vector3.left * Speed, ForceMode.Force);
        }

        if(Input.GetKey(RightKeyName))
        {
            RB.AddForce(FacingDirection * Vector3.right * Speed, ForceMode.Force);
        }

        if(Input.GetKey(UpKeyName))
        {
            RB.AddForce(FacingDirection * Vector3.up * Speed, ForceMode.Force);
        }

        if(Input.GetKey(DownKeyName))
        {
            RB.AddForce(FacingDirection * Vector3.down * Speed, ForceMode.Force);
        }
        
        //Apply force in the opposite direction of the ball's motion on brake key press 
        if(Input.GetKey(BrakeKeyName)){
            Vector3 MotionDirection = Vector3.Normalize(RB.velocity);
            RB.AddForce(-MotionDirection * Speed, ForceMode.Force);
        }
    }
}
