using UnityEngine;
using System.Collections;

public class ControlarCamara : MonoBehaviour {
	public GameObject player;//el personaje en tercera persona
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
