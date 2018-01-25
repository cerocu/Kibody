using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cRiñon : MonoBehaviour {

	GameObject objeto;	
	Tiempito tiempo;
	public Canvas canvas;

	public GameObject reproductor;

	private AudioSource audio;
	public AudioClip sonido;
	public AudioClip audioCorrecto;

	public AudioClip audioError;
	public void Start(){
		Debug.Log("posicion del ri"+this.transform.position);
		audio = GetComponent<AudioSource> ();
	}
	void desaparecer(GameObject obj){
		if (obj.gameObject.name == "mriñon") {
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			objeto = GameObject.Find ("riñon2");
			objeto.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			this.gameObject.SetActive (false);



			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = audioCorrecto;
			reproductor.GetComponent<AudioSource> ().Play ();
		} else {
			Object.Destroy (this.gameObject.GetComponent<FixedJoint>());
			audio.clip = audioError;
			audio.Play ();	
			this.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
			this.transform.position=new Vector3(0.4f,1.2f,1.6f);//Translate(new Vector3(0.565f,1.58f,-2.044146f));//
				}
	}
		void OnCollisionEnter (Collision col)
		{
		if(col.gameObject.tag=="cubo"){
			//audio.clip = sonido;
			//audio.Play ();	

			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = sonido;
			reproductor.GetComponent<AudioSource> ().Play ();
		}
			if(col.gameObject.tag == "Marcadores"){
			 
				Debug.Log("Chocho con "+col.gameObject.name);
				Debug.Log ("Nombre :" + this.gameObject.name);
				desaparecer(col.gameObject);
			}
		}
}
