using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{	
	public void restartLevel(){
		Time.timeScale = 1f;
		DeathMenu.isDead = false;
		PauseMenu.GameIsPaused = false;		
		Application.LoadLevel(Application.loadedLevel);
	}
}
