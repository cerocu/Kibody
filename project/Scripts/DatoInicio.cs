using UnityEngine;
using System.Collections;

public class DatoInicio : MonoBehaviour {
	public static DatoInicio dato;
	public static string seleccion="cabeza";
	public static string avatar = "lisaChan";
	public static string nivel="facil";
	public static string puntaje="";
	// Use this for initialization

	void Awake(){
		if (dato == null) {
			dato = this;
			DontDestroyOnLoad (gameObject);
		} else if (dato != null) {
			Destroy (gameObject);
		}
	}

	public string getSeleccion(){
		return seleccion;
	}

	public void setSeleccion(string a){
		seleccion = a;
	}

	public string getPuntaje(){
		return puntaje;
	}

	public void setPuntaje(string a){
		puntaje = a;
	}

	public void setAvatar(string a){
		avatar= a;
	}

	public  string getAvatar(){
		return avatar;
	}
		

	public void setNivel(string a){
		nivel= a;
	}

	public  string getNivel(){
		return nivel;
	}
}
