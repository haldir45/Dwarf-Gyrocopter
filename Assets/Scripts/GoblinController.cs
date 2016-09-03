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
	private bool facingRight = false;


	//animation
	Animator anim;

	//Position Vectors,distance between gyrocopter and enemy
	Vector2 gyrocopterPosition;
	Vector2 goblinPosition;
	//float dist =0.0f;
	public int randDistLimits;


	public float timeLeft = 1.5f;

	public int goblinMaxHitPoints = 3;
	int goblinHitPoints;

	public void Init()
	{
		
		//
	//	goblinHitPoints = goblinMaxHitPoints;

		//this.gameObject.SetActive (true);
		//Debug.Log ("GobblinHitPoints:"+goblinHitPoints);

	}
	// Use this for initialization
	void Start () {
		//reference to Rigibody2d
		rb = GetComponent<Rigidbody2D> ();

		//reference to animator
		anim = GetComponent<Animator> ();

	 randDistLimits = Random.Range (1, 12);
	

	}
	
	// Update is called once per frame
	void Update () {
		 gyrocopterPosition = Gyrocopter.transform.position;
		 goblinPosition = this.transform.position;
		// dist = Vector2.Distance(gyrocopterPosition, goblinPosition);
	

		//Debug.Log ("Dist" + dist +"Gyrocopter x:"+(int)gyrocopterPosition.x+"Goblin"+(int)goblinPosition.x+"enabled"+anim.GetBool("move"));

	}

	void FixedUpdate()
	{

		float x = (gyrocopterPosition - goblinPosition).x;
		if (x < 0 && (facingRight)) {
			Flip ();
		} else if (x > 0 && (!facingRight)) {
			Flip ();
		}
		/*
		if ((int)gyrocopterPosition.x == (int)goblinPosition.x  || dist < randDistLimits ) {
			anim.SetFloat ("moveSpeed", 0.09f);

		
		} else if (gyrocopterPosition.x > goblinPosition.x) {
			//Flip ();
			//goblinPosition = new Vector2 (goblinPosition.x + speed * Time.deltaTime, goblinPosition.y);
			//this.transform.position = goblinPosition;
			moveVertical = 0.101f;
			//anim.SetFloat ("moveSpeed", 0.101f);
		} else {
			//Flip ();
		//	goblinPosition = new Vector2 (goblinPosition.x - speed * Time.deltaTime, goblinPosition.y);
			//this.transform.position = goblinPosition;
			moveVertical = -0.101f;
			//anim.SetFloat("moveSpeed",Mathf.Abs(-0.101f));
		}

		if ((moveVertical == 0.101f) && (!facingRight)) {
			Flip ();

		} else if ((moveVertical == -0.101f) && (facingRight)) {
			Flip ();
		}
		*/

	
	
	}


	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}


	void OnTriggerEnter2D(Collider2D col){
		

		//Detect collision of the gyrocopter bomb with an object
		if (col.tag == "GyrocopterProjectile" ) {
			Debug.Log ("Hello");
			goblinMaxHitPoints--;
			//Debug.Log ("GoblinHitPoints:" + goblinHitPoints);

			if (goblinMaxHitPoints==0)
				Destroy(gameObject);
	
		

		}

	}

	//Ignore the collision if child collide with parent
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "EnemyProjectileRange")
			return; // do nothing
		
	}
}

