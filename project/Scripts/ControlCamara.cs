using UnityEngine;
using System.Collections;

public class ControlCamara : MonoBehaviour {

	// Use this for initialization
	public GameObject camera1;
	public GameObject camera2;
	DatoInicio d;
	void Start () {
		Debug.Log("camara 1 desactivado camara 2 activado");
		d = GameObject.Find ("Datos").GetComponent<DatoInicio> ();
		if (d.getSeleccion ()== "cuerpo") {
			Debug.Log ("entro como la camara del cuerpo");
			camera1.GetComponent<Camera> ().enabled = true;
			camera2.GetComponent<Camera> ().enabled = false;
		}
		else 
		{camera1.GetComponent<Camera> ().enabled = true;
			camera2.GetComponent<Camera> ().enabled = false;}
	}

	void OnTriggerEnter (Collider otro){
		if (d.getSeleccion () == "cuerpo") {
			if (otro.gameObject.tag == "morro_man" || otro.gameObject.tag == "lisaChan") {
				Debug.Log ("Chocho contra" + otro.gameObject.name);
				camera1.GetComponent<Camera> ().enabled = false;
				camera2.GetComponent<Camera> ().enabled = true;

			}
		}
	}

	void OnTriggerExit(Collider otro){
		Debug.Log ("salio de la mesa");
		if (d.getSeleccion () == "cuerpo") {
			if (otro.gameObject.tag == "morro_man" || otro.gameObject.tag == "lisaChan") {
				Debug.Log ("Chocho contra" + otro.gameObject.name);
				camera1.GetComponent<Camera> ().enabled = true;
				camera2.GetComponent<Camera> ().enabled = false;

			}
		}
	}
	public void posicionarCamara(){
		Debug.Log ("cambiando camara");

		//camera1.GetComponent<Camera>().enabled = false;
		//camera2.GetComponent<Camera>().enabled = true;

	}
	/*
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "morro_man"){
			Debug.Log("Chocho contra"+col.gameObject.name);
			camera1.GetComponent<Camera>().enabled = false;
			camera2.GetComponent<Camera>().enabled = true;

		}
	}


	void OnCollisionExit(Collision col){
		Debug.Log ("fuera");
		if(col.gameObject.tag == "morro_man"){
			Debug.Log("Chocho contra"+col.gameObject.name);
			camera1.GetComponent<Camera>().enabled = true;
			camera2.GetComponent<Camera>().enabled = false;

		}
	}*/

}
