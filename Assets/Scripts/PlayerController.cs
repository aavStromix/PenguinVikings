using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

	public Vector2 mainVector = new Vector3(0,0);
	Rigidbody2D rb;
	public float vel;
    // Use this for initialization
    private Animator anim;


    void Start () {
        anim = GetComponent<Animator>();
		if (isLocalPlayer) {
			GameObject cameraObj = GameObject.Find ("Main Camera"); // add camera
			cameraObj.GetComponent<CameraFixed> ().person = transform; // setup camera
		}
    }

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}
	

	// Update is called once per frame
	void FixedUpdate () {

		if (isLocalPlayer) {
			Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			float angle = Angle (mouse, transform.position);
			transform.rotation = Quaternion.Euler (0f, 0f, angle + 90f);
			mainVector = (mouse - transform.position);
			mainVector = mainVector.normalized;
			vel = mainVector.magnitude;
		}
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce (mainVector * 10);
			anim.SetBool ("isMoving", true);
		} else {
			anim.SetBool ("isMoving", false);
		}
	}

	public static float Angle(Vector3 start, Vector3 end)
	{
		float angle=Mathf.Atan2(end.y-start.y, end.x-start.x)*180/Mathf.PI;
		return angle;
	}

	void OnDestroy()
	{
		if (isLocalPlayer) {
			GameObject cameraObj = GameObject.Find ("Main Camera"); 
			cameraObj.GetComponent<CameraFixed> ().person = null;
		}
	}
}
