using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TorchLightControl : MonoBehaviour {
	
	public GameObject Torch;
	public GameObject TorchLight;
	public ParticleSystem TorchFlame;
	public Image foregroundImage;
	public GameObject TorchProgressBar;
	public float TorchDuration;
	public float IntensityLight;
	private float timer;

	void Start () {
		//Start Flame
		GameMechanics.TourchLightStatus = true;

		//Set Light itensity
		TorchLight.GetComponent<Light>().intensity=IntensityLight;

		//Need to stop particles before set new duration
		TorchFlame.Stop ();
		var main = TorchFlame.main;
		main.duration = TorchDuration;
		TorchFlame.Play ();

		//Make sure progress bar is off
		TorchProgressBar.gameObject.SetActive(false);
	}
	

	void Update () {
		//Torches time managment
		//Last torch
		if (GameMechanics.numberTorches == 1) {
			timer += Time.deltaTime;
			//Start Progress bar
			TorchProgressBar.gameObject.SetActive(true);
			foregroundImage.fillAmount = timer / TorchDuration;
			//Turn off torch, reset related stuff
			if (timer > (TorchDuration)) {
				GameMechanics.TourchLightStatus = false;
				GameMechanics.playerIsSafe = false;
				Torch.SetActive(false);
				TorchLight.SetActive(false);
				TorchProgressBar.gameObject.SetActive(false);
				timer = 0f;
				GameMechanics.numberTorches--;
			}
		}
		//More than one torch
		else if (GameMechanics.numberTorches > 1) {
			timer += Time.deltaTime;
			//Start Progress bar
			TorchProgressBar.gameObject.SetActive(true);
			foregroundImage.fillAmount = timer / TorchDuration;
			//Reset timer and remove torch
			if (timer > (TorchDuration)) {
				timer = 0f;
				GameMechanics.numberTorches--;
				TorchFlame.Play ();
			}
		}
	}
}
