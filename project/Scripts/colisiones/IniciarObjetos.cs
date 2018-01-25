using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class IniciarObjetos : MonoBehaviour {
	public GameObject[] objeto;
	public GameObject[] objetosModoJuego; 
	public GameObject[] marcadores; 
	public GameObject[] organosFuera; 
	public GameObject obj;
	public  int contaModojuego;
	private Canvas canvas;
	//agregado
	public  int contador;
	public int final;
	public  Text timerText;
	public  Text tiemp;
	public Text puntaje;
	private  float startTime;
	string tiempoFinal;
	//

	DatoInicio d;
	void Start(){
		contador=0;
		startTime =Time.time;
		puntaje.text = "";
		canvas = (Canvas)GameObject.Find ("Canvas").GetComponent<Canvas>();
		canvas.gameObject.SetActive(false);
		d = GameObject.Find ("Datos").GetComponent<DatoInicio> ();
		objeto = GameObject.FindGameObjectsWithTag("Organos");
		// organosFuera = GameObject.FindGameObjectsWithTag("Organosfuera");
		//agregar  el total de  organos 
		if(d.getPuntaje()!=""){
			puntaje.text ="Record "+d.getPuntaje();
		}


		marcadores = GameObject.FindGameObjectsWithTag("Marcadores");
		if(d.getNivel()=="Intermedio")
			for(int i=0;i<marcadores.Length;i++){
				marcadores[i].gameObject.GetComponentInChildren<Renderer>().enabled = false;

			}

		if (d.getAvatar () == "spiderman") {
			GameObject lisa = GameObject.Find ("lisaChan");
			lisa.SetActive (false);

		} else {

			GameObject c = GameObject.Find ("morro_man");
			c.SetActive (false);
		}

		if(d.getSeleccion()=="cuerpo"){
			GameObject c=GameObject.Find("cabeza");
			c.SetActive (false);
			c = GameObject.Find ("organosCabeza");
			c.SetActive (false);
			contaModojuego = 0;
			organosFuera = GameObject.FindGameObjectsWithTag("Organos");
			objetosModoJuego=new GameObject[organosFuera.Length];
			Debug.Log ("lollololo poeoeoeoeoeo");
			for (int i = 0; i < organosFuera.Length; i++)
			{
				if (organosFuera[i].gameObject.GetComponentInChildren<Renderer>().enabled) {
					objetosModoJuego [contaModojuego] = organosFuera[i];
					Debug.Log (objetosModoJuego[contaModojuego].name);
					contaModojuego+=1;
				}
			}
			ocultarOrganos ();
		}else if(d.getSeleccion()=="cabeza"){
			GameObject c=GameObject.Find("esqueleto");
			c.SetActive (false);
			c = GameObject.Find ("organosCuerpo");
			c.SetActive (false);
			contaModojuego = 0;
			organosFuera = GameObject.FindGameObjectsWithTag("Organos");
			objetosModoJuego=new GameObject[organosFuera.Length];
			for (int i = 0; i < organosFuera.Length; i++)
			{
				if (organosFuera[i].gameObject.GetComponentInChildren<Renderer>().enabled) {
					objetosModoJuego [contaModojuego] = organosFuera[i];

					Debug.Log (objetosModoJuego[contaModojuego].name);
					contaModojuego+=1;
				}
			}

			ocultarOrganos ();

		}
		else{
			Debug.Log ("El valor de inicio no es valido: " + d.getSeleccion());
		}
		final=objetosModoJuego.Length-1;
	}

	public void ocultarOrganos(){

		for (int i = 0; i < objeto.Length; i++)
		{
			Debug.Log("Elementos identificado: "+objeto[i].name);
			objeto[i].gameObject.GetComponentInChildren<Renderer>().enabled = false;
		}
	}

	void  Update(){
		float t=Time.time - startTime;
		string minutes=((int) t/60).ToString();
		string seconds=(t % 60).ToString();

		timerText.text=minutes + ":" + seconds;

		if(final>-1){
			if(objetosModoJuego[final].gameObject.GetComponentInChildren<Renderer>().enabled){
				final--;
			}
		}
		if(final==-1){//-1//1 para cabeza
			Debug.Log("perfectoooooooooooooooooooooooooooooooo000000000000000000000000000000000000000000000");
			final--;
			GameObject tiempu=GameObject.Find("score");
			tiempu.SetActive (true);
			tiemp.text+=" Record :  "+minutes + ":" + seconds+" puedes  llegar  a  mejorarlo ;)";
			//desactiva  contador
			GameObject conta=GameObject.Find("timer Text");
			conta.SetActive (false);
			d.setPuntaje (minutes + ":" + seconds);
			tiempo ();
			final = -5;
			objetosModoJuego = null;
			objeto = null;
			marcadores = null;
			organosFuera = null;
			Application.LoadLevel ("KinectOverlayDemo");
			//GameObject eskeleton=(GameObject)GameObject.Find("skeleton@Stand Up");
			//eskeleton.SetActive (true);
			//
		}

	}
	IEnumerator tiempo()
	{
		yield return new WaitForSecondsRealtime(13);
	}

}