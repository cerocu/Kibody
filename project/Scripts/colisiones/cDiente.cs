using UnityEngine;
using System.Collections;

public class cDiente : MonoBehaviour
{
	GameObject objeto;	
	Tiempito tiempo;
	public Canvas canvas;

	private AudioSource audio;
	public AudioClip sonido;

	public AudioClip audioCorrecto;
	public GameObject reproductor;
	public AudioClip audioError;
	public void Start(){
		Debug.Log("posicion de dentadura de cabeza "+this.transform.position);
		audio = GetComponent<AudioSource> ();
	}
	void desaparecer(GameObject obj){
		if (obj.gameObject.name == "marcadorDiente") {
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			objeto = GameObject.Find ("dentadura");
			objeto.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			this.gameObject.SetActive (false);


			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = audioCorrecto;
			reproductor.GetComponent<AudioSource> ().Play();
		} else {
			Object.Destroy (this.gameObject.GetComponent<FixedJoint>());
			this.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
			//audio.clip = audioError;
			//audio.Play ();	
			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = audioError;
			reproductor.GetComponent<AudioSource> ().Play ();
			this.transform.position=new Vector3(0.4f,1.1f,1.6f);//Translate(new Vector3(0.565f,1.58f,-2.044146f));//
			this.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
		}
	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag=="cubo"){
			Debug.Log ("Aqui no va esta parte :(");
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

