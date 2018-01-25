using UnityEngine;
using System.Collections;

public class PosicionCamara : MonoBehaviour {

	// Use this for initialization
	DatoInicio d;
	void Start () {

		d = GameObject.Find ("Datos").GetComponent<DatoInicio> ();
		if (d.getSeleccion() == "cabeza") {
			//transform.position = new Vector3 (-0.2f, 2.0f, 2.6f);
		//	transform.Rotate (new Vector3 (-32.3f, 8.5f, -7.2f));

			transform.position = new Vector3 (-0.3f, 1.8f, 2.6f);
			//transform.Rotate (new Vector3 (-32.3f, 8.5f, -7.2f));
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
