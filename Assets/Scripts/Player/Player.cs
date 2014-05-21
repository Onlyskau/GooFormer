using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	//Movement
	protected float maxSpeed = 10f;
	


	//Jump
	protected bool grounded = false;
	protected float groundRadius = 0.2f;
	protected float jumpForce = 400f;
	protected bool doubleJump = false;

	public LayerMask whatIsGround;
	public Transform groundCheck;


	// Facing
	bool facingRight = true;


	// Health
	protected int health;
	protected float immunityCD = 0f;
	public int HealthTracker;

	// Scripted Event
	public bool Speech;
	protected bool canMove = true;

	// Goo Level
	public int Goo = 10;

	public Transform GooPos;
	public GameObject PieceOfGoo;
	

	// Camera
	public GameObject PlayerCam;
	protected float ScaleTime = 0.1f;
	
	// Use this for initialization
	void Start () 
	{
		//anim = GetComponent<Animator>();
		health = 100;

		transform.localScale = new Vector3(0.1f, 0.1f,0f);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		

			
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			
		if(grounded)
			doubleJump = true;
			
			
			
		float move = Input.GetAxis ("Horizontal");
			

		if(canMove)
		{
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		}
			


		if(move > 0 && !facingRight)
			Flip();
		else if(move < 0 && facingRight)
			Flip();

		
	}
	
	void Update ()
	{
		HealthTracker = health;

		if(canMove)
		{

			if((grounded || !doubleJump) && Input.GetButtonDown ("Jump"))
			{
				rigidbody2D.AddForce(new Vector2(0, jumpForce));
		

				if(!doubleJump && !grounded)
					doubleJump = true;
			}
				
			if(Input.GetKeyDown(KeyCode.S))
			{
				if(Goo > 1)
				{
					GetLow();
					GameObject GooBall = Instantiate(PieceOfGoo, GooPos.position, GooPos.rotation) as GameObject; // spawns the gameobejct by the assigned position and rotation
				}
			}
		}


	}

		


	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void Speechset() {
		if(Speech == false)
		{
			Speech = true;
			canMove = false;
		} else {
			Speech = false;
			canMove = true;
		}
	}

	public void TakeDamage(int damage){		
		if(immunityCD < Time.time){			
			health -= damage;							
			if(health < 1)					
				Destroy(gameObject);		
			immunityCD = Time.time + 0.25f;	
		}									
	}

	public void Grow(){
		if(facingRight)
			transform.localScale += new Vector3(0.01f, 0.01f,0f);
		
		if(!facingRight)
			transform.localScale += new Vector3((0.01f*-1), 0.01f,0f);


		maxSpeed += 1f;
		jumpForce += 10f;
		Goo += 1;

		CameraScript camScript = PlayerCam.gameObject.GetComponent<CameraScript>();

		camScript.startTime = ScaleTime + Time.time;
		camScript.startValue += 0.4f;
		camScript.endValue += 0.4f;

		camScript.ZoomOut();
	}

	public void GetLow(){
		if(facingRight)
		transform.localScale -= new Vector3(0.01f, 0.01f,0f);

		if(!facingRight)
		transform.localScale -= new Vector3((0.01f*-1), 0.01f,0f);

		maxSpeed -= 1f;
		jumpForce -= 10f;
		Goo -= 1;

		CameraScript camScript = PlayerCam.gameObject.GetComponent<CameraScript>();

		camScript.startTime = ScaleTime + Time.time;
		camScript.startValue -= 0.4f;
		camScript.endValue -= 0.4f;

		camScript.ZoomIn();
	}


	void OnDestroy(){
		HealthTracker = 0;
	}

}
