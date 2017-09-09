using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManagement : MonoBehaviour {
	
	public Button Continue;
	public Animator IntroAnimation;

	void Start () {
		/*Scene loadLevel = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (loadLevel.buildIndex);*/
		Continue.gameObject.SetActive(false);
		IntroAnimation = GetComponent<Animator> ();
		IntroAnimation.PlayInFixedTime ("IntroCameraAnimation", -1, 0f);
	}

	public void ContinueButtonShow () {
		Continue.gameObject.SetActive(true);
	}

	public void ContinueButtonPress () {
		SceneManager.LoadScene("MainGame");
	}
}
