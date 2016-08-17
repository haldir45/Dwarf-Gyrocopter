using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public GameObject Explosion;
	Vector2 direction;
	// Use this for initialization
	void Start () {
		//	spearRB = GetComponent<Rigidbody2D> ();


		//	direction = gyrocopter.position - transform.position;
		//	spearRB.velocity = (gyrocopter.position-goblin.transform.position).normalized * speed;
		//	//spearRB.AddForce (new Vector2(direction.x,direction.y), ForceMode2D.Impulse);



		//	spearRB.AddForce (direction, ForceMode2D.Impulse);
		//spearRB.AddForce (new Vector2(Random.Range (-spearAngle, spearAngle), Random.Range (spearSpeedLow, spearSpeedHigh)), ForceMode2D.Impulse);


		//spearRB.AddForce (Vector2.Distance(gyrocopter.transform.position, goblin.transform.position), ForceMode2D.Impulse);
	}

	// Update is called once per frame
	void Update () {
		
		//Vector2 position = transform.position;

	//	position +=direction * Time.deltaTime;

		//transform.position=position;

		//direction = gyrocopter.transform.position -goblin.transform.position  ;
		//Debug.Log ("Dir:" + direction);



	}

	public void SetDirection(Vector2 direction)
	{
		this.direction = direction.normalized;

	}
	void OnTriggerEnter2D(Collider2D col){

		//Detect collision of the gyrocopter bomb with an object
		if (col.tag == "Enemy" || col.tag == "Tower" || col.tag == "Ground") {
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
