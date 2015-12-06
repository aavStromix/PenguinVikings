using UnityEngine;
using System.Collections;

public class SnowBallController : MonoBehaviour {

	public Rigidbody2D snowball;				// Prefab of the rocket.
	public float speed = 30f;

	private PlayerController playerCtrl;
	// Use this for initialization
	void Start () {
		playerCtrl = transform.root.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			Rigidbody2D bulletInstance = Instantiate(snowball, transform.position, Quaternion.Euler(playerCtrl.mainVector.normalized)) as Rigidbody2D;
			bulletInstance.AddForce(playerCtrl.mainVector.normalized * speed);
		}
	}
}
