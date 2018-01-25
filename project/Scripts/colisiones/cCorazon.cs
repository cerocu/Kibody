using UnityEngine;
using System.Collections;

public class cCorazon : MonoBehaviour {

    GameObject objeto;	
	Tiempito tiempo;
	public Canvas canvas;
	//public AudioClip audio;

	private AudioSource audio;
	public AudioClip sonido;
	public AudioClip audioError;
	public AudioClip audioCorrecto;

	public GameObject reproductor;

	public void Start(){
		Debug.Log("posicion del corazon"+this.transform.position);
		//audio = GetComponent<AudioSource> ();
		audio = GetComponent<AudioSource> ();

	}
	void desaparecer(GameObject obj){
		if (obj.gameObject.name == "mcorazon") {
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			objeto = GameObject.Find ("corazon2");
			objeto.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			this.gameObject.SetActive (false);
			Debug.Log ("Choco con marcadorCorazon");


			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = audioCorrecto;
			reproductor.GetComponent<AudioSource> ().Play ();
		} else {
			Debug.Log ("Choco con un marcador incorrecto");
			this.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			this.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
			Object.Destroy (this.gameObject.GetComponent<FixedJoint>());
			//audio.clip = audioError;
			//audio.Play ();	



			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = audioError;
			reproductor.GetComponent<AudioSource> ().Play ();
			this.transform.position=new Vector3(-0.8f,1.1f,1.7f);//Translate(new Vector3(0.565f,1.58f,-2.044146f));//

			//(new Vector3(0,0,1));//0.565,1.58,-2.04414));
		}

	}	
		void OnCollisionEnter (Collision col)
	    {


		if (col.gameObject.tag == "cubo") {
			
			//tiempo = new Tiempito ();
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
