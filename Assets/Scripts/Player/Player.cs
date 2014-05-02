using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	//Movement
	protected float maxSpeed = 10f;
	


	//Jump
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 100f;
	bool doubleJump = false;


	// Facing
	bool facingRight = true;

	
	
	// Use this for initialization
	void Start () 
	{
		//anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		

			
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			
		if(grounded)
			doubleJump = false;
			
			
			
		float move = Input.GetAxis ("Horizontal");
			
			
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
			


		if(move > 0 && !facingRight)
			Flip();
		else if(move < 0 && facingRight)
			Flip();

		
	}
	
	void Update ()
	{

		if((grounded || !doubleJump) && Input.GetButtonDown ("Jump"))
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
	

			if(!doubleJump && !grounded)
				doubleJump = true;
		}
			
		if(Input.GetKeyDown(KeyCode.S))
		{

		}


	}

		


	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
