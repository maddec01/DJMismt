using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointControl : MonoBehaviour {

	public GameObject CheckPoint;
	public GameObject TorchLight;
	public Text Popup;
	
	void OnCollisionStay (Collision collisionInfo) {
		if (collisionInfo.collider.name == "Player") {
			if (!CheckPoint.activeSelf) {
				if (GameMechanics.TourchLightStatus == true) {
					Popup.GetComponent<Text> ().text = "PRECIONE 'E' PARA ACENDER O CALDEIRÃO";
					if (Input.GetKeyDown (KeyCode.E)) {
						CheckPoint.SetActive (true);
					}
				} else if (GameMechanics.TourchLightStatus == false) {
					if (GameMechanics.numberTorches == 0) {
						Popup.GetComponent<Text> ().text = "PRECISA DE UMA TOCHA PARA ACENDER O CALDEIRÃO";
					} else if (GameMechanics.numberTorches > 0) {
						Popup.GetComponent<Text> ().text = "PRECISA DE UMA TOCHA ACESA PARA ACENDER O CALDEIRÃO";
					}
				}
			}
			if (CheckPoint.activeSelf) {
				if (GameMechanics.TourchLightStatus == false) {
					if (GameMechanics.numberTorches == 0) {
						Popup.GetComponent<Text> ().text = "PRECISA DE ENCONTRAR UMA TOCHA";
					}
					else if (GameMechanics.numberTorches > 0) {
						Popup.GetComponent<Text> ().text = "PRECIONE 'E' PARA ACENDER A TOCHA";
						if (Input.GetKeyDown (KeyCode.E)) {
							GameMechanics.TourchLightStatus = true;
							TorchLight.SetActive (true);
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
		if (CheckPoint.activeSelf) {
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