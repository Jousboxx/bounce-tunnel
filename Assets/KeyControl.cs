using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    //Control names in Unity for Control keys (not hardcoded so keys are remappable)
    //[SerializeField] makes the field appear in the unity editor
    [SerializeField] private string boostKey = "space";

    [SerializeField] private string latchKey = "w";

    Rigidbody RB;
    private float Speed = 20.0f;

    private float tempVelocity = 0;

    private Vector3 lastVelocity;

    private bool latchEngaged = false;

    //Accessed by BouncePad methods for facilitating the latch timing
    public float timeSinceBounce = 0;

    private float framesSinceBoost;

    //True while the latch key is being held down, regardless of engagement or bounce time
    private bool latchKeyPressed;

    //Stores the rotation direction that the playerBall is facing
    private Quaternion FacingDirection;

    Vector3 impulse;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceBounce += Time.deltaTime * 60.0f;
        framesSinceBoost += Time.deltaTime * 60.0f;
        //Update FacingDirection
        FacingDirection = RB.rotation;


        //Apply forces on ball on boost key press
        if(Input.GetKeyDown(boostKey) && NewBehaviourScript.currTime >= 1){
            RB.AddForce(RB.velocity * (-0.6f), ForceMode.Impulse);
            RB.AddForce(FacingDirection * Vector3.forward * Speed, ForceMode.Impulse);
            NewBehaviourScript.currTime -= (Time.deltaTime * 60.0f);
            framesSinceBoost = 0;
        }else if(framesSinceBoost > 1){
            //We know we didn't boost this frame or the last frame
            //So now we can proceed with confidence on super hacky bounce detection

            if(Mathf.Abs(RB.velocity.x - lastVelocity.x) >  Mathf.Abs(lastVelocity.x)){
                timeSinceBounce = 0;
            }

            if(Mathf.Abs(RB.velocity.y - lastVelocity.y) > Mathf.Abs(lastVelocity.y)){
                timeSinceBounce = 0;
            }

            if(Mathf.Abs(RB.velocity.z - lastVelocity.z) > Mathf.Abs(lastVelocity.z)){
                timeSinceBounce = 0;
            }


        }

        //Control latchKeyPressed
        if(Input.GetKeyDown(latchKey)){
            latchKeyPressed = true;
        }else if(Input.GetKeyUp(latchKey)){
            latchKeyPressed = false;
        }

        //Engage latch on press
        if(latchKeyPressed && (! latchEngaged)){
            if(timeSinceBounce < 30 && NewBehaviourScript.currTime > 1.0f){
                 engageLatch();
            }
        }

        //Disengage latch on release
        if((! latchKeyPressed) && latchEngaged){
            disengageLatch();

        }

        //Deduct mana for engaging latch, if mana goes under 0, disengage latch
        if(latchEngaged){

            if(NewBehaviourScript.currTime < 0.2f){
                disengageLatch();
                NewBehaviourScript.currTime = 0.0f;
            }else{
                NewBehaviourScript.currTime -= (Time.deltaTime * 30.0f) * 0.2f;
            }   
        }
        lastVelocity = RB.velocity;
    }

    void engageLatch(){
        tempVelocity = RB.velocity.magnitude;
        RB.velocity = new Vector3(0, 0, 0);
        latchEngaged = true;
    }

    void disengageLatch(){
        impulse = (FacingDirection * Vector3.forward * (tempVelocity * 1.2f)); //Give a slight boost on latch release
        RB.AddForce(impulse, ForceMode.Impulse);

        //Boost mana upon release of latch
        NewBehaviourScript.currTime += 6.0f;
        if(NewBehaviourScript.currTime > 10.0f){
            NewBehaviourScript.currTime = 10.0f;   
        }

        latchEngaged = false;
    }
}
