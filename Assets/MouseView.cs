using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseView : MonoBehaviour
{

    //Control names in Unity for mouse X and Y
    [SerializeField] private string MouseXName = "Mouse X";
    [SerializeField] private string MouseYName = "Mouse Y";

    //Stores a reference to the ball's RigidBody
    Rigidbody RB;
    private float Yaw = 0f;
    private float Pitch = 0f;
    private float SpeedX = 2.0f;
    private float SpeedY = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
		if(!PauseMenu.GameIsPaused){
        //Add mouse motions to the Yaw and Pitch variables
        Yaw += SpeedX * Input.GetAxis(MouseXName);
        Pitch -= SpeedY * Input.GetAxis(MouseYName);

        //Transform the angle of this object (the ball)
        transform.eulerAngles = new Vector3(Pitch, Yaw, 0.0f);
		}

    }

    public static void LockCursor(){
        Cursor.lockState = CursorLockMode.Locked;
    }
}
