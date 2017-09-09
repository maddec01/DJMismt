using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointControl : MonoBehaviour {

	public Animator UseTorchAnimation;
	public GameObject CheckPointFlame;
	public GameObject TorchLight;
	public Text Popup;
	
	public void OnCollisionStay (Collision collisionInfo) {
		if (collisionInfo.collider.name == "Player") {
			if (!CheckPointFlame.activeSelf) {
				if (GameMechanics.TourchLightStatus == true) {
					Popup.GetComponent<Text> ().text = "PRESS <color=#EC2027>E</color> USE THE TORCH";
					if (Input.GetKeyDown (KeyCode.E)) {
						UseTorchAnimation.PlayInFixedTime ("UseIgnitedTorch", -1, 0f);
						CheckPointFlame.SetActive (true);
					}
				}
				else if (GameMechanics.TourchLightStatus == false) {
					if (GameMechanics.numberTorches == 0) {
						Popup.GetComponent<Text> ().text = "YOU NEED A TORCH TOO IGNITE";
					}
					else if (GameMechanics.numberTorches > 0) {
						Popup.GetComponent<Text> ().text = "THE TORCH IS NOT IGNITED";
					}
				}
			}
			if (CheckPointFlame.activeSelf) {
				if (GameMechanics.TourchLightStatus == false) {
					if (GameMechanics.numberTorches == 0) {
						Popup.GetComponent<Text> ().text = "YOU NEED A TORCH";
					}
					else if (GameMechanics.numberTorches > 0) {
						Popup.GetComponent<Text> ().text = "PRESS <color=#EC2027>E</color> TO IGNITE TORCH";
						if (Input.GetKeyDown (KeyCode.E)) {
							//This also triggers an event
							UseTorchAnimation.PlayInFixedTime ("IgniteTorch");
						}
					}
				}
			}
		}
	}

	void OnCollisionExit (Collision collisionInfo) {
		Popup.GetComponent<Text>().text = "";
	}

	void OnTriggerStay (Collider collisionInfo) {
		if (CheckPointFlame.activeSelf) {
			GameMechanics.playerIsSafe = true;
		}
	}

	void OnTriggerExit (Collider collisionInfo) {
		if (GameMechanics.TourchLightStatus == true) {
			GameMechanics.playerIsSafe = true;
		}
		else if (GameMechanics.TourchLightStatus == false) {
			GameMechanics.playerIsSafe = false;
		}
	}
}