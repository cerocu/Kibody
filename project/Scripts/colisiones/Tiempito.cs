using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tiempito : MonoBehaviour {
	public float tiempo;
	private Wikipedia wikipedia;
	public float tiempoMaximo = 5.0f;

	private Text texto;
	private Canvas canvas;
	// Use this for initialization

	public void setCanvas(Canvas c, string a){
		wikipedia = new Wikipedia ();
		this.canvas = c;
		canvas.gameObject.SetActive(true);

	//	GameObject.Find ("Image").SetActive(true);
		texto = (Text)GameObject.Find ("Texto").GetComponent<Text>();

		string informacion = wikipedia.buscarWikipedia (a);

		texto.text = (informacion.Split('.')[0]+"."+informacion.Split('.')[1]+".");

	}

}
