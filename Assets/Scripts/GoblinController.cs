using UnityEngine;
using System.Collections;

public class GoblinController : MonoBehaviour {



	//GameObjects
	public GameObject Gyrocopter;
	public GameObject Projectile;
	public GameObject ProjectilePosition;

	//Physics
	private Rigidbody2D rb;



	//movement
	public float speed ;
	public float moveVertical;

	//facing
	private bool facingRight = true;


	//animation
	Animator anim;

	//Position Vectors,distance between gyrocopter and enemy
	Vector2 gyrocopterPosition;
	Vector2 goblinPosition;
	float dist =0.0f;


	public float timeLeft = 1.5f;
	// Use this for initialization
	void Start () {
		//reference to Rigibody2d
		rb = GetComponent<Rigidbody2D> ();

		//reference to animator
		anim = GetComponent<Animator> ();

	

		

	}
	
	// Update is called once per frame
	void Update () {
		 gyrocopterPosition = Gyrocopter.transform.position;
		 goblinPosition = this.transform.position;
		 dist = Vector2.Distance(gyrocopterPosition, goblinPosition);


		//Debug.Log ("Dist" + dist +"Gyrocopter x:"+(int)gyrocopterPosition.x+"Goblin"+(int)goblinPosition.x+"enabled"+anim.GetBool("move"));

	}

	void FixedUpdate()
	{
		
		if ((int)gyrocopterPosition.x == (int)goblinPosition.x  || dist > 5.0 ) {
			anim.SetFloat ("moveSpeed", 0.09f);

		
		} else if (gyrocopterPosition.x > goblinPosition.x) {
			//Flip ();
			goblinPosition = new Vector2 (goblinPosition.x + speed * Time.deltaTime, goblinPosition.y);
			this.transform.position = goblinPosition;
			moveVertical = 0.101f;
			anim.SetFloat ("moveSpeed", 0.101f);
		} else {
			//Flip ();
			goblinPosition = new Vector2 (goblinPosition.x - speed * Time.deltaTime, goblinPosition.y);
			this.transform.position = goblinPosition;
			moveVertical = -0.101f;
			anim.SetFloat("moveSpeed",Mathf.Abs(-0.101f));
		}

		if ((moveVertical == 0.101f) && (!facingRight)) {
			Flip ();

		} else if ((moveVertical == -0.101f) && (facingRight)) {
			Flip ();
		}


			//Calls the throwProjectile after 2 seconds
			timeLeft -= Time.deltaTime;
		if (timeLeft < 0 & Gyrocopter.activeSelf) {
			  
				throwProjectile ();
				timeLeft = 1.5f;
			}

		




	}

	void throwProjectile()
	{
		//instantiate an enemy projectile
		GameObject spear = (GameObject)Instantiate (Projectile);

		//set the projectile's initial position
		spear.transform.position = transform.position;

		//compute the projectile's direction towards the Gyrocopter
		Vector2 direction = Gyrocopter.transform.position - spear.transform.position;

		//set the projectile's direction
		spear.GetComponent<Projectile>().SetDirection (direction);

		Rigidbody2D rb = spear.GetComponent<Rigidbody2D>();

		//add force to the projectile
		rb.AddForce (direction, ForceMode2D.Impulse);

		// destroy the projectile after 2 secs
		Destroy (spear, 2);

	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

	void OnTriggerEnter2D(Collider2D col){

		//Detect collision of the gyrocopter bomb with an object
		if (col.tag == "GyrocopterBomb") {

			Destroy (gameObject);

		}

	}

}
