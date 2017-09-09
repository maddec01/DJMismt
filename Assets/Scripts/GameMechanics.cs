using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMechanics : MonoBehaviour {

	public Animator UseTorchAnimation;
	public GameObject Torch;
	public GameObject TorchLight;
	public GameObject PausePanel;
	public static bool TourchLightStatus;
	public static bool playerIsSafe;
	public static bool playerIsDead;
	public static int numberTorches;
	public float OutOfLightTime;
	private float OutOfLightTimer;
	public Text PickPopup;
	public Text SafeStatus;
	public Text NumberOfTorches;

	void Start () {
		//Make sure status is reset
		Torch.SetActive(false);
		TorchLight.SetActive(false);
		PausePanel.SetActive(false);
		TourchLightStatus = false;
		playerIsSafe = false;
		playerIsDead = false;
		numberTorches = 0;
	}

	void OnCollisionStay (Collision collisionInfo) {
		//Collide with bonfire
		if (collisionInfo.collider.name == "modelBonfire") {
			if (numberTorches == 0) {
				PickPopup.GetComponent<Text> ().text = "YOU NEED TO FIND A TORCH";
			}
			else if (numberTorches > 0 && TourchLightStatus == false) {
				PickPopup.GetComponent<Text> ().text = "PRESS <color=#EC2027>E</color> TO LIGHT THE TORCH";
				if (Input.GetKeyDown (KeyCode.E)) {
					//This also triggers an event
					UseTorchAnimation.PlayInFixedTime ("IgniteTorch");
				}
			}
		}
	}

	void OnCollisionExit (Collision collisionInfo) {
		if (collisionInfo.collider.name == "modelBonfire") {
			PickPopup.GetComponent<Text> ().text = "";
		}
	}

	void OnTriggerEnter (Collider collisionInfo) {
		if (collisionInfo.GetComponent<Collider>().name == "ExitTrigger") {
			Debug.Log ("win");
		}
	}

	void OnTriggerStay (Collider collisionInfo) {
		if (collisionInfo.GetComponent<Collider>().name == "modelBonfire") {
			playerIsSafe = true;
		}
	}

	void OnTriggerExit (Collider collisionInfo) {
		if (TourchLightStatus == true) {
			playerIsSafe = true;
		}
		if (TourchLightStatus == false) {
			playerIsSafe = false;
		}
	}

	void Update () {
		//Prints Number of torches
		if (numberTorches == 0) {
			NumberOfTorches.GetComponent<Text> ().text = "";
		}
		else if (numberTorches != 0) {
			NumberOfTorches.GetComponent<Text> ().text = numberTorches.ToString ();
		}

		//Check Player safe status
		if (playerIsSafe == true) {
			SafeStatus.GetComponent<Text>().text = "OK";
			OutOfLightTimer = 0f;
		}
		else if (playerIsSafe == false) {
			if (playerIsDead == false) {
				SafeStatus.GetComponent<Text>().text = "Move to light";
			}
			OutOfLightTimer += Time.deltaTime;
			if (OutOfLightTimer > (OutOfLightTime)) {
				SceneManager.LoadScene("GameOver");
			}
		}

		//Pause menu
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (!PausePanel.activeSelf) {
				PauseGame ();
			}
			else if (PausePanel.activeSelf) {
				ContinueGame ();
			}
		}
	}

	public void PauseGame () {
		Time.timeScale = 0;
		PausePanel.SetActive(true);
		//Unlock mouse
		//Not needed already implemented in MouseLook InternalLockUpdate(), mouse wasn't in focus after continue
	}

	public void ContinueGame () {
		Time.timeScale = 1;
		PausePanel.SetActive(false);
		//Lock mouse (not needed)
	}

	public void ExitToMain () {
		SceneManager.LoadScene("StartMenu");
	}
}