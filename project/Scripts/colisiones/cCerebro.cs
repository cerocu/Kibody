using UnityEngine;
using System.Collections;

public class cCerebro : MonoBehaviour
{
	GameObject objeto;	
	Tiempito tiempo;
	public Canvas canvas;


	private AudioSource audio;
	public AudioClip sonido;

	public GameObject reproductor;
	public AudioClip audioError;

	public AudioClip audioCorrecto;

	public void Start(){
		Debug.Log("posicion del cerebro cabeza "+this.transform.position);
		audio = GetComponent<AudioSource> ();
	}
	void desaparecer(GameObject obj){
		if (obj.gameObject.name == "marcadorCerebro") {
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;


			obj = GameObject.Find ("temporal");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			obj = GameObject.Find ("cerebelm");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			obj = GameObject.Find ("frontal");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			obj = GameObject.Find ("ocipital");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			obj = GameObject.Find ("parietal");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			obj = GameObject.Find ("stem");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			//Destroy (this);
			//this.gameObject.SetActive (false);
			Debug.Log ("choco con cerebro cabeza");


			obj = GameObject.Find ("parte1");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			obj = GameObject.Find ("parte2");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			obj = GameObject.Find ("parte3");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			obj = GameObject.Find ("parte4");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			obj = GameObject.Find ("parte5");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			obj = GameObject.Find ("parte6");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			obj = GameObject.Find ("cerebro2");
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			//for(int i=0;i<6;i++){
			//	obj = GameObject.Find ("partes"+i);
				//obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
				
			//}

			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = audioCorrecto;
			reproductor.GetComponent<AudioSource> ().Play();
			Debug.Log ("Bien");
		} else {
			Object.Destroy (this.gameObject.GetComponent<FixedJoint>());
			Debug.Log ("MAL");
			//audio.clip = audioError;
			//audio.Play ();	

			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = audioError;
			reproductor.GetComponent<AudioSource> ().Play ();
			this.transform.position=new Vector3(-0.9f,1.1f,1.9f);//Translate(new Vector3(0.565f,1.58f,-2.044146f));//
			this.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
		}
	}

	void OnCollisionEnter (Collision col)
	{    Debug.Log ("nombre del objeto con que choco "+this.name);
		
		if(col.gameObject.tag=="cubo"){
			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = sonido;
			reproductor.GetComponent<AudioSource> ().Play();
			//audio.clip = sonido;
			//audio.Play ();	
		}
		if(col.gameObject.tag == "Marcadores"){


			Debug.Log("Chocho con "+col.gameObject.name);
			Debug.Log ("Nombre :" + this.gameObject.name);
			desaparecer(col.gameObject);
		}
	}

}

