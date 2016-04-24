using UnityEngine;
using System.Collections;

public class GyrocopterController : MonoBehaviour {

	//Bombs
	public GameObject GyrocopterBomb; //this is gyrocopter's bomb prefab
	public GameObject GyrocopterBombPosition;


	//Physics
	private Rigidbody2D rb;

	//movement
	private float moveHorizontal = 0.0f;
	private float moveVertical = 0.0f;
	public float smooth = 2.0F;
	public float tiltAngleRight = 30.0F;
	public float tiltAngleLeft = -30.0F;
	public float speed = 5.0f;

	bool hover = false;
	bool flyingHigh = false;

	public Transform hoverCheck;
	public Transform highAltitudeCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public LayerMask whatIsHighAltitude;


	private bool facingRight = true;

	public AudioSource gyrocopterMovementAudio;          
	public AudioClip gyrocopterEngineDriving;  



	//animation
	Animator anim;



	// Use this for initialization
	void Start () {
	  //reference to Rigibody2d
		rb = GetComponent<Rigidbody2D> ();

		//reference to animator
		anim = GetComponent<Animator> ();

		gyrocopterMovementAudio.clip = gyrocopterEngineDriving;
		gyrocopterMovementAudio.Play();


	}
	
	// Update is called once per frame
	void Update () {

		//fire bombs when the spacebar is pressed
		if (Input.GetKeyDown ("space")) {
			GameObject bomb = (GameObject)Instantiate (GyrocopterBomb);

			bomb.transform.position = GyrocopterBombPosition.transform.position;
			Debug.Log ("X:"+bomb.transform.position.x +"Y:"+ bomb.transform.position.y);

		}
		//Input only in update
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");

		    checkingHover ();
			fixingAngle ();
		/*
		//check for jump
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//Invoke("PlayJumpSound", 0.4f);
			rb.AddForce (new Vector2 (0, 2.5f), ForceMode2D.Impulse);
		} 
		*/


	}

	//physics only in FixedUpdate
	void FixedUpdate(){
		hover = Physics2D.OverlapCircle (hoverCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", hover);

		flyingHigh = Physics2D.OverlapCircle (highAltitudeCheck.position, groundRadius, whatIsHighAltitude);
		anim.SetBool ("flyingHigh", flyingHigh);

		rb.velocity = new Vector2 (moveHorizontal * speed, rb.velocity.y);

		rb.velocity = new Vector2 (rb.velocity.x, moveVertical * speed);


	
		anim.SetFloat ("moveHorizontal", Mathf.Abs (moveHorizontal));

	
		anim.SetFloat ("moveVertical", Mathf.Abs (moveVertical));

	

		if ((moveHorizontal > 0) && (!facingRight)) {
			Flip ();
		
		} else if ((moveHorizontal < 0) && (facingRight)) {
			Flip ();
		}


	
	}  
	void Flip(){
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;

		transform.localScale = theScale;
	}

	void fixingAngle(){
		
		if (facingRight) {
	
			//float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
			float tiltAroundX = Input.GetAxis ("Vertical") * tiltAngleRight;
			Quaternion target = Quaternion.Euler (tiltAroundX, 0, tiltAroundX);
			transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);
		} else {
			
			float tiltAroundX = Input.GetAxis ("Vertical") * tiltAngleLeft;
			Quaternion target = Quaternion.Euler (tiltAroundX, 0, tiltAroundX);
			transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);
		}

	}
		
	void checkingHover(){

		if (hover || flyingHigh) {
			tiltAngleRight = 0.0f;
			tiltAngleLeft = 0.0f;
			smooth = 10.0f;

		} else {
			tiltAngleRight = 30.0f;
			tiltAngleLeft = -30.0f;
			smooth = 2.0f;
		}

	}





	
}
