using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Colision2 : MonoBehaviour {
	private FixedJoint unir;
	public float blastRadius;
	Collider[] hitColliders;

	void aparecer(GameObject obj){
		Debug.Log("Aparecio:"+obj.gameObject.name);
		GameObject corazon = GameObject.Find ("mcorazon");

		corazon.gameObject.GetComponentInChildren<Renderer>	().shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
		obj.gameObject.GetComponentInChildren<Renderer>	().shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.On;
		Debug.Log (obj.gameObject.GetComponentInChildren<MeshRenderer>().enabled );
	}

	void ExplosionDamage(Vector3 center) {
		hitColliders = Physics.OverlapSphere(center, blastRadius);
		int i = 0;
		while (i < hitColliders.Length) {
			Debug.Log ("origen de "+hitColliders[i].gameObject.name); 
			hitColliders[i].gameObject.GetComponentInChildren<Renderer>	().shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
			Debug.Log(hitColliders[i].gameObject.GetComponentInChildren<Renderer>	().shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly);
			i++;
		}
	}


	void OnCollisionEnter (Collision col)
	{/*0
		if (this.gameObject.name == "Cuboderecho") {
		//	unir = col.gameObject.AddComponent<FixedJoint>();
		//	unir.connectedBody = this.gameObject.GetComponent<Rigidbody>();
			Debug.Log ("destruir "+col.gameObject.GetComponent<FixedJoint>().name);
			Object.Destroy (col.gameObject.GetComponent<FixedJoint>());
			Debug.Log ("accediendo "+	col.gameObject.GetComponent<FixedJoint>().name);


		}

		if (this.gameObject.name == "Cube") {
		//	unir = col.gameObject.AddComponent<FixedJoint>();
		//	unir.connectedBody = this.gameObject.GetComponent<Rigidbody>();
			Debug.Log ("destruir "+col.gameObject.GetComponent<FixedJoint>().name);
			Object.Destroy (col.gameObject.GetComponent<FixedJoint>());
			Debug.Log ("accediendo "+	col.gameObject.GetComponent<FixedJoint>().name);


		}*/
		if(col.gameObject.tag == "Organosfuera"){
			Debug.Log("Chocho con"+col.gameObject.name);
			Object.Destroy (col.gameObject.GetComponent<FixedJoint>());

			//desaparecer(col.gameObject);
			Debug.Log("datos"+this.transform.position);
			col.rigidbody.constraints=RigidbodyConstraints.FreezeRotation;
			unir = col.gameObject.AddComponent<FixedJoint>();
			unir.connectedBody = this.gameObject.GetComponent<Rigidbody>();
		}


		Debug.Log ("el nombre es "+this.gameObject.name);

	}

}