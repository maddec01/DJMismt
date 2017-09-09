using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour 
{
	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

	void Start () {
		quitMenu.enabled = false;
		//Unlock mouse
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void ExitPress() {
		quitMenu.enabled = true;
		startText.gameObject.SetActive(false);
		exitText.gameObject.SetActive(false);
	}

	public void NoPress() {
		quitMenu.enabled = false;
		startText.gameObject.SetActive(true);
		exitText.gameObject.SetActive(true);
	}

	public void StartLevel () {
		SceneManager.LoadScene("MainGame");
	}

	public void ExitGame () {
		Application.Quit();
	}

}