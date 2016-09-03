using UnityEngine;
using System.Collections;

public class GoblinShooting : MonoBehaviour {
	
	//GameObjects
	public GameObject Gyrocopter;
	public GameObject Projectile;
	public GameObject ProjectilePosition;

	public float shootTime;
	float nextShootTime;
	public int i =0;
	// Use this for initialization
	void Start () {
	
		nextShootTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){


		if (col.tag == "Gyrocopter" && nextShootTime <Time.time ) {
			i++;

			nextShootTime = Time.time + shootTime;
		
				throwProjectile ();

			
		}

	}

	//Ignore the collision if child collide with parent
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
			return; // do nothing
		

	}
	void throwProjectile()
	{

		GameObject spear = (GameObject)Instantiate (Projectile, transform.position, Quaternion.identity);


		//compute the projectile's direction towards the Gyrocopter
		Vector2 direction = Gyrocopter.transform.position - ProjectilePosition.transform.position;

		//set the projectile's direction
		spear.GetComponent<Spear>().SetDirection (direction);

		Rigidbody2D rb = spear.GetComponent<Rigidbody2D>();

		//add force to the projectile
		rb.AddForce (direction, ForceMode2D.Impulse);
		//	rb.velocity = direction* 10*Time.deltaTime;

		// destroy the projectile after 2 secs
		Destroy (spear, 5);



	}

}