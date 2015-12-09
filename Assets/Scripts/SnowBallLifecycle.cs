using UnityEngine;
using System.Collections;

public class SnowBallLifecycle : MonoBehaviour {

	public ParticleSystem snowFlash;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D myCollision)
	{
		if (!myCollision.gameObject.tag.Equals("Player"))
		{

			ParticleSystem flash = Instantiate(snowFlash) 
				as ParticleSystem;
			flash.transform.position = transform.position;
			flash.Play();

			Destroy(flash.gameObject, 2);

			Destroy(gameObject);
		}
	}
}
