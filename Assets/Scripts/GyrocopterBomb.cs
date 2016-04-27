using UnityEngine;
using System.Collections;

public class GyrocopterBomb : MonoBehaviour {

	float speed;
	public GameObject Explosion;// this our prefab explosion

	// Use this for initialization
	void Start () {
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
    
		//Get the bullet's current position
		Vector2 position = transform.position;



		//compute the bullet's new position
		//position = new Vector2 (position.x,position.y - speed * Time.deltaTime);

		//update the bullet's position
		//transform.position = position;



		/*
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		if (transform.position.y < min.y) {
			Destroy (gameObject);
		}
              */

	}

	void OnTriggerEnter2D(Collider2D col){
		//Detect collision of the gyrocopter bomb with an object
		if (col.tag == "Ground") {
			PlayExplosion ();	
			Destroy (gameObject);
		
		}

	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (Explosion);

		//set the position of the explosion
		explosion.transform.position = transform.position;
	}
}
