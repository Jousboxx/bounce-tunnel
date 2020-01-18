using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggler : MonoBehaviour
{
	public static bool GameIsPaused = false;
	
	[SerializeField] private string PauseKeyName = "p";
	
	public GameObject pauseMenuUI;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//when escape is pressed, the object is set to an active state that it isn't currently in
        //if(Input.GetKeyDown(KeyCode.Escape))
		if(Input.GetKeyDown(PauseKeyName))
		{
			if(GameIsPaused){
				Resume();
				Cursor.lockState = CursorLockMode.Locked;
			}
			else {
				Pause();
				Cursor.lockState = CursorLockMode.None;
			}
		}
    }
	void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
}
