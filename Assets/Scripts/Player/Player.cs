using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	//Movement
	protected float maxSpeed = 10f;
	


	//Jump
	protected bool grounded = false;
	protected float groundRadius = 0.2f;
	protected float jumpForce = 500f;
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
	public int Goo = 1;

	public Transform GooPos;
	public GameObject PieceOfGoo;

	// Death
	public GameObject DeadText;
	
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
			doubleJump = false;
			
			
			
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
				transform.localScale -= new Vector3(0.01f, 0.01f,0f);
				GameObject Goo = Instantiate(PieceOfGoo, GooPos.position, GooPos.rotation) as GameObject; // spawns the gameobejct by the assigned position and rotation
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

	void OnDestroy(){
		HealthTracker = 0;
		//GameObject Dead = Instantiate(DeadText, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
	}

}
