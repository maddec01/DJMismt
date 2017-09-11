using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	void Start () {
		//Unlock cursor
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void QuitToMain () {
		SceneManager.LoadScene("StartMenu");
	}
}
