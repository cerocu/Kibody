using UnityEngine;
using System.Collections;

public class cOjo2 : MonoBehaviour
{

	GameObject objeto,objeto2;
	Tiempito tiempo;
	public Canvas canvas;


	public GameObject reproductor;

	private AudioSource audio;
	public AudioClip sonido;
	public AudioClip audioCorrecto;

	public AudioClip audioError;
	public void Start(){
		Debug.Log("posicion de ojo Batman"+this.transform.position);
		audio = GetComponent<AudioSource> ();
	}
	void desaparecer(GameObject obj){
		if (obj.gameObject.name == "marcadorOjo") {
			obj.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			Destroy (obj);
			objeto = GameObject.Find ("ojoB1");
			objeto.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			objeto = GameObject.Find ("ojoB2");
			objeto.gameObject.GetComponentInChildren<Renderer> ().enabled = true;
			this.gameObject.SetActive (false);


			reproductor.GetComponent<AudioSource> ().Stop();

			reproductor.GetComponent<AudioSource> ().clip = audioCorrecto;
			reproductor.GetComponent<AudioSource> ().Play();
		} else {
			Object.Destroy (this.gameObject.GetComponent<FixedJoint>());
			//audio.clip = audioError;
			//audio.Play ();

			reproductor.GetComponent<AudioSource> ().Stop();
			reproductor.GetComponent<AudioSource> ().clip = audioError;
			reproductor.GetComponent<AudioSource> ().Play ();
			this.transform.position=new Vector3(-0.8f,1.1f,1.7f);//Translate(new Vector3(0.565f,1.58f,-2.044146f));//
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

