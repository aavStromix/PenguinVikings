using UnityEngine;
using System.Collections;

public class SnowBallLifecycle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionStay2D(Collision2D myCollision)
	{
		if (!myCollision.gameObject.tag.Equals("Player"))
			Destroy(gameObject);
	}
}
