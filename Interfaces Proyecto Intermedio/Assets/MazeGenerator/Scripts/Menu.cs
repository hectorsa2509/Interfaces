using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour {
	InputField nombreText;
	string nombre;
	GameObject aceptar;
	Button boton;

	// Use this for initialization
	void Start(){


		GameObject inputNombre = GameObject.Find ("h");
		nombreText = inputNombre.GetComponent<InputField> ();
		aceptar = GameObject.Find ("i");
		boton = aceptar.GetComponent<Button> ();
		boton.onClick.AddListener (() => {
			Entrar();
		});

	}

	void Entrar(){
		SceneManager.LoadScene("demo");
		Debug.Log(nombre);


	}

	void Update(){
		nombre = nombreText.text;


	}
}