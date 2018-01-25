using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class controlador : MonoBehaviour {
	public GameObject objetoinformacion;

	public void jugar(){
		print ("cambiando a juego");
		//SceneManager.LoadScene (nombreEscena);

		Application.LoadLevel("modojuego 1");

	}
	public void informacion(){
		Instantiate (objetoinformacion);
	}

	public void salir(){
		print ("Saliendo....");
		Application.Quit ();
	}
}
