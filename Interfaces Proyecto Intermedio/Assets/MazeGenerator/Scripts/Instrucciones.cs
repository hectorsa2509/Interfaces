using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Instrucciones : MonoBehaviour {


		GameObject aceptar;
		Button boton;

		// Use this for initialization
		void Start(){


		aceptar = GameObject.Find ("p");
			boton = aceptar.GetComponent<Button> ();
			boton.onClick.AddListener (() => {
				Entrar();
			});

		}

		void Entrar(){
			SceneManager.LoadScene("Juego");



		}


}