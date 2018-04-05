using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempo : MonoBehaviour {
	public float time;

	// Use this for initialization
	void Start () {

		time = 30;
	}

	void Update() {
		if(time > 0){
			time -= Time.deltaTime;
		}
		if(time <= 0) {
			Application.LoadLevel ("Fin");
		}

	}

}
