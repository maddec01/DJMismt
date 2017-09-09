using UnityEngine;
using System.Collections;

public class TorchLightControl : MonoBehaviour {
	
	public GameObject Torch;
	public GameObject TorchLight;
	public ParticleSystem TorchFlame;
	public float TorchDuration;
	public float IntensityLight;
	private float timer;

	void Start () {
		//Start Flame
		GameMechanics.TourchLightStatus = true;
		//light
		TorchLight.GetComponent<Light>().intensity=IntensityLight;
		//need to stop particles before set new duration
		TorchFlame.Stop ();
		var main = TorchFlame.main;
		main.duration = TorchDuration;
		TorchFlame.Play ();
	}
	

	void Update () {
		
		if (GameMechanics.numberTorches == 1) {
			timer += Time.deltaTime;
			if (timer > (TorchDuration)) {
				GameMechanics.TourchLightStatus = false;
				GameMechanics.playerIsSafe = false;
				Torch.SetActive(false);
				TorchLight.SetActive(false);
				timer = 0f;
				GameMechanics.numberTorches--;
			}
		}

		else if (GameMechanics.numberTorches > 1) {
			timer += Time.deltaTime;
			if (timer > (TorchDuration)) {
				timer = 0f;
				GameMechanics.numberTorches--;
				TorchFlame.Play ();
			}
		}
	}
}
