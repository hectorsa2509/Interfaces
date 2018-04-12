using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Recoleccion : MonoBehaviour {
	public float time;
	GameObject aceptar;
	Button boton;


	// Use this for initialization
	void Start () {

		time = 15;
		aceptar = GameObject.Find ("FIFO");
		boton = aceptar.GetComponent<Button> ();
		boton.onClick.AddListener (() => {
			Entrar();
		});
	}

	void Update() {
		if(time > 0){
			time -= Time.deltaTime;
		}
		if(time <= 0) {
			Application.LoadLevel ("Fin");
		}

	}


	void Entrar(){
		SceneManager.LoadScene("Fin");
	}

}
