﻿using UnityEngine;
using System.Collections;

public class CarryObject : MonoBehaviour
{
    public float interactDistance = 3;
    public float carryDistance = 2.5f;
    public LayerMask interactLayer;

    private Transform carryObject;
    private bool haveObject;
	public float blastRadius;
	Collider[] hitColliders;

	void ExplosionDamage(Vector3 center) {
		 hitColliders = Physics.OverlapSphere(center, blastRadius);
			int i = 0;
			while (i < hitColliders.Length) {
			Debug.Log (hitColliders[i].gameObject.name); 

			Debug.Log (hitColliders[i].gameObject.transform.position); 
			//	hitColliders[i].SendMessage("AddDamage");
			RaycastHit hit;
			Ray ray = new Ray(hitColliders[i].gameObject.transform.position,hitColliders[i].gameObject.transform.forward);
			Physics.Raycast (ray, out hit, interactDistance, interactLayer);
			carryObject = hit.transform;
			carryObject.GetComponent<Rigidbody>().useGravity = false;
			haveObject = true;

			carryObject.position = Vector3.Lerp(carryObject.position, Camera.main.transform.position + Camera.main.transform.forward * carryDistance, Time.deltaTime * 8);
			carryObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				i++;
			}
		}
	void OnCollisionEnter(Collision col){
		ExplosionDamage(col.contacts[0].point);


	}
    void Update()
    {
        //Raycast variables.
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        //Raycasting mechanics.
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            //If we press LMB, it will update the carryObject and its gravity.
            //if (Input.GetMouseButtonDown(0))
            {
                carryObject = hit.transform;
                carryObject.GetComponent<Rigidbody>().useGravity = false;
                haveObject = true;
            }
        }

        //If we release LMB and we have an object in hand, it will reset the carryObject.
        //if (Input.GetMouseButtonUp(0))
        {
           // if (haveObject)
            {
                haveObject = false;
                carryObject.GetComponent<Rigidbody>().useGravity = true;
                carryObject = null;
            }
        }

        //If we have an object in hand, we update its position and smooth it out with basic interpolation.
       // if (haveObject)
        {
            carryObject.position = Vector3.Lerp(carryObject.position, Camera.main.transform.position + Camera.main.transform.forward * carryDistance, Time.deltaTime * 8);
            carryObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}