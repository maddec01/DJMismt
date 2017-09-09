using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour {

	public void Start () {
		//Unlock mouse
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void RestartLevel () {
		SceneManager.LoadScene("MainGame");
	}

	public void QuitToMain () {
		SceneManager.LoadScene("StartMenu");
	}

}
