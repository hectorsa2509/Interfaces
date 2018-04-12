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
			Data.C = Data.Cl = Data.H = Data.N = Data.Na = Data.O = Data.P = Data.S = 0;
			Data.total = 0;
			SceneManager.LoadScene("Juego");



		}


}