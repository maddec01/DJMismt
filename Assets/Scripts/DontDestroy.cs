using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	//Make the sound keep playing after changing scnene
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
}
