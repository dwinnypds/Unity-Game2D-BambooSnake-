using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Mene : MonoBehaviour {

	public void StartGame(){
		SceneManager.LoadScene ("Gameplay");
	}

	public void BacktoMenu(){
		SceneManager.LoadScene("Menu");
	}

	public void ExitGame(){
		Application.Quit ();
	}

}
