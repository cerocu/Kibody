using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Colision : MonoBehaviour {
	public GameObject objeto;	
	
	void desaparecer(GameObject obj){
		Debug.Log("Aparecio:"+obj.gameObject.name);
		obj.gameObject.GetComponentInChildren<Renderer>().enabled = true;
	}
	
    void OnCollisionEnter (Collision col)
    {
    		if(col.gameObject.tag == "Elementos"){
    		Debug.Log("Chocho con"+col.gameObject.name);

			 desaparecer(col.gameObject);
    		}
    }
    
}