using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour 
{
	public float maxSpeed = 8.0f;
	public float climbSpeed = 5.0f;
	public float jumpForce = 150.0f;
	public float dropForce = -12.0f;
	bool facingRight = true;

	// Grounding Variables for falling and jumping
	public bool isGrounded;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask ground; // define what objects count as ground

	public bool isClimbing;
	public Transform climbCheck;
	public float ladderRadius = 0.2f;
	public LayerMask ladder;

	void FixedUpdate () 
	{
		// Will return whether the character is grounded
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
		isClimbing = Physics2D.OverlapCircle(climbCheck.position, ladderRadius, ladder);

		float horizontalMovement = Input.GetAxis("Horizontal");

		rigidbody2D.velocity = new Vector2(horizontalMovement * maxSpeed, rigidbody2D.velocity.y);

		if(!isGrounded) {
			rigidbody2D.AddForce (new Vector2 (0.0f, dropForce));
		}

		if(horizontalMovement > 0 && !facingRight)
		{
			Flip ();
		}
		else if (horizontalMovement < 0 && facingRight)
		{
			Flip ();
		}
	}

	void Update()
	{
		float verticalMovement = Input.GetAxis("Vertical");

		// Jump Functionality
		if(verticalMovement > 0 && isGrounded && !isClimbing)
		{
			rigidbody2D.AddForce (new Vector2 (0.0f, jumpForce));
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject == GameObject.FindWithTag ("Ladder")) {
			if(Input.GetAxis("Vertical") > 0 && isClimbing) {
//				Debug.Log ("Climbing...");
				rigidbody2D.isKinematic = true;
				transform.Translate (Vector2.up * climbSpeed * Time.deltaTime);
			}
			if(Input.GetAxis("Vertical") < 0 && isClimbing) {
				rigidbody2D.isKinematic = true;
				transform.Translate (-Vector2.up * climbSpeed * Time.deltaTime);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == GameObject.FindWithTag ("Ladder")) {
			rigidbody2D.isKinematic = false;
		}
	}
}
