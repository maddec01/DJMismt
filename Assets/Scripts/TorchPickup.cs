using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchPickup : MonoBehaviour {

	public GameObject Torch;
	public Text pickPopup;

	void OnCollisionStay (Collision collisionInfo) {

		pickPopup.GetComponent<Text>().text = "PRESS 'E' TO PICK TORCH";

		if (Input.GetKeyDown (KeyCode.E)) {
			//First torch
			if (GameMechanics.numberTorches == 0) {
				Torch.SetActive(true);
				pickPopup.GetComponent<Text>().text = "";
				GameMechanics.numberTorches++;
				Destroy(gameObject);
			}
			//Collect Torches
			else if (GameMechanics.numberTorches >= 1) {
				pickPopup.GetComponent<Text>().text = "";
				GameMechanics.numberTorches++;
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionExit (Collision collisionInfo) {
		pickPopup.GetComponent<Text>().text = "";
	}
}
