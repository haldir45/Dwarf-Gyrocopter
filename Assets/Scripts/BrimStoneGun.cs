using UnityEngine;
using System.Collections;

public class BrimStoneGun : MonoBehaviour {
	Animator anim;
	//Projectile
	public GameObject Projectile;

	public GameObject Gyrocopter;

	// Use this for initialization
	void Start () {
		//reference to animator
		anim = Gyrocopter.GetComponent<Animator> ();
	}

	void Update()
	{
		//Debug.Log ("facing " + anim.GetBool ("facing"));
		//fire projectiles
		if (Input.GetKeyDown (KeyCode.G)) {

			//instantiate an enemy projectile
			GameObject bullet = (GameObject)Instantiate (Projectile, transform.position, Quaternion.identity);

			Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();


			if (anim.GetBool("facing")) {
				//add force to the projectile
				rb.AddForce (Vector2.right, ForceMode2D.Impulse);
			} else {
				//add force to the projectile
				rb.AddForce (Vector2.left, ForceMode2D.Impulse);
			}


		
			Destroy (bullet, 5);

		}
	}
	// Update is called once per frame
	void FixedUpdate () {


	}
}
