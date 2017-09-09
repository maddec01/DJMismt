using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchUseEvent : MonoBehaviour {

	public GameObject TorchLight;
	public CheckPointControl CheckPoint;

	public void LightTheTorch () {
		GameMechanics.TourchLightStatus = true;
		TorchLight.SetActive (true);
	}
}
