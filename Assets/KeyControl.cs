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
    private float Speed = 800.0f;

    private float tempVelocity = 0;

    private Vector3 lastVelocity;

    private bool latchEngaged = false;

    //Accessed by BouncePad methods for facilitating the latch timing
    public int timeSinceBounce = 0;

    private int framesSinceBoost;

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
        timeSinceBounce ++;
        framesSinceBoost ++;
        //Update FacingDirection
        FacingDirection = RB.rotation;


        //Apply forces on ball on up directional key press
        if(Input.GetKeyDown(boostKey) && NewBehaviourScript.currTime >= 3.333){
            RB.AddForce(FacingDirection * Vector3.forward * Speed, ForceMode.Force);
            NewBehaviourScript.currTime -= 3.333f;
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
            if(timeSinceBounce < 30){
                 engageLatch();
            }else{
                print("whoops! timeSinceBounce is " + timeSinceBounce);
            }
           
        }

        //Disengage latch on release
        if(! latchKeyPressed && latchEngaged){
            disengageLatch();

        }

        lastVelocity = RB.velocity;
    }

    void engageLatch(){
        tempVelocity = RB.velocity.magnitude / 2; //Don't ask me when this needs to be divided by 2, it just does
        RB.velocity = new Vector3(0, 0, 0);
        latchEngaged = true;
    }

    void disengageLatch(){
        impulse = (FacingDirection * Vector3.forward * tempVelocity);
        RB.AddForce(impulse, ForceMode.Impulse);
        latchEngaged = false;
    }
}
