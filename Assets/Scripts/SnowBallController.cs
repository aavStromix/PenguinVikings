using UnityEngine;
using System.Collections;

public class SnowBallController : MonoBehaviour {

	public Rigidbody2D snowball;				// Prefab of the rocket.
	private float speed = 1000f;

	private PlayerController playerCtrl;
	private Animator anim;

	// Use this for initialization
	void Start () {
		playerCtrl = transform.root.GetComponent<PlayerController>();
		anim = transform.root.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			anim.SetBool ("isThrowing", true);
			Rigidbody2D bulletInstance = Instantiate (snowball, transform.position, Quaternion.Euler (playerCtrl.mainVector.normalized)) as Rigidbody2D;
			bulletInstance.AddForce (playerCtrl.mainVector.normalized * speed);
		} else {
			anim.SetBool ("isThrowing", false);
		}
	}
}
