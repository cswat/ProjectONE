using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {

	public bool facingRight = true;
	public bool jump = true;

	public float moveForce = 365;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
	
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

	}//Awake
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown("Jump") && grounded) //If the jump button is pressed AND the user's grounded state is true... (needs to be changed for double jump)
		{
			jump = true;//...then jump
		}//if

	}//Update

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (h)); //12:00 - 13:11

		if (h * rb2d.velocity.x < maxSpeed)
			{
				rb2d.AddForce (Vector2.right * h * moveForce);
			}//if

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			{
				rb2d.velocity = new Vector2 (Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
			}//if

		if (h > 0 && !facingRight)
			{
				Flip ();
			}//if
		else if (h < 0 && facingRight) 
			{
				Flip ();
			} //else if

		if (jump)
			{
			anim.SetTrigger ("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
			}//if

	} //FixedUpdate

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	} //flip
}
