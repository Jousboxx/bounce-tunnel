using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public static bool isDead = false;
	
	[SerializeField] private string DeathKeyName = "l";//for testing purposes
	
	public GameObject deathMenuUI;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(isDead){
			PauseMenu.GameIsPaused = true;
			Cursor.lockState = CursorLockMode.None;
			deathMenuUI.SetActive(true);
			Time.timeScale = 0f;
		}
    }
}
