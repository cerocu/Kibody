using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class cPulmon : MonoBehaviour {
	GameObject objeto;	
	Tiempito tiempo;
	public Canvas canvas;

	public AudioClip audioCorrecto;

	private AudioSource audio;
	public AudioClip sonido;

	public GameObject reproductor;

	public AudioClip audioError;
	public void Start(){
		Debug.Log("posicion de pulmon "+this.transform.position);
		audio = GetComponent<AudioSource> ();
	}
	void desaparecer(GameObject obj){
		if (obj.gameObject.name == "mpulmon") {
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			objeto = GameObject.Find ("pulmones2");
			objeto.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			this.gameObject.SetActive (false);



			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = audioCorrecto;
			reproductor.GetComponent<AudioSource> ().Play ();

		} else {
			Object.Destroy (this.gameObject.GetComponent<FixedJoint>());
			audio.clip = audioError;
			audio.Play ();	
			this.transform.position=new Vector3(0.3f,1.3f,1.8f);//Translate(new Vector3(0.565f,1.58f,-2.044146f));//
			this.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;

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