using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggler : MonoBehaviour
{
	public static bool GameIsPaused = false;
	
	public GameObject pauseMenuUI;

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//when escape is pressed, the object is set to an active state that it isn't currently in
        if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(GameIsPaused){
				Resume();
			}
			else {
				Pause();
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
