using UnityEngine;
using System.Collections;

public class CameraFixed : MonoBehaviour {


	public Vector3 offset; // пишем в инспекторе (0,0,10)
	public Transform person;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = person.position + offset;
	}
}
