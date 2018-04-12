using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour {
	private GameObject tmp;
	private double timer;
	public double t;

	public GameObject[] vistas;

	// Use this for initialization
	void Start () {
		tmp = null;
		t = 0.8;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer >= t)
			dis ();
	}

	void dis(){
		if (tmp == null)
			return;

		tmp.SetActive (false);
		tmp = null;
	}

	GameObject find(string s){
		for (int i = 0; i < 8; i++) {
			GameObject obj = vistas [i];
			//Debug.Log (s);
			//Debug.Log ("Tag: "+this.tag);
			if (obj.tag.Equals (s))
				return obj;
			
		}
		return null;
	}

	public void Elemento(string s){
		dis ();
		GameObject obj = find (s);

		obj.SetActive (true);

		timer = 0;
		tmp = obj;
	}
}
