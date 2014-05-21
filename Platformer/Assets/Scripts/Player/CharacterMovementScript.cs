using UnityEngine;
using System.Collections;

public class CharacterMovementScript : MonoBehaviour 
{
	//public float moveSpeed = 5.0f;
	public float moveForce = 3.0f;
	public float maxVelocity = 10f;
	public float jumpForce = 15f;
	public float distance = .5f;
	public float groundTime = .75f;
	float curGroundTime = 0.0f;

	public string groundTag = "Ground";

	bool canJump = true;
	bool goingRight = true;
	
	void Update () 
	{
		HorizontalMove();
		if(canJump)
			Jump ();

		if(canJump && curGroundTime != groundTime)
			curGroundTime = groundTime;

		if(rigidbody.velocity.y < .01f && canJump == false)
		{
			curGroundTime -= Time.deltaTime;
			if(curGroundTime <= 0.0f)
			{
				canJump = true;
				curGroundTime = groundTime;
			}
		}
	}

	void HorizontalMove()
	{
		if(Input.GetAxisRaw("Horizontal") > 0)
		{
			if(!goingRight)
				transform.eulerAngles = Vector3.zero;

			if(rigidbody.velocity.x < maxVelocity)
				rigidbody.AddForce(moveForce * Vector3.right, ForceMode.Impulse);
			else
				rigidbody.velocity = new Vector3(maxVelocity, rigidbody.velocity.y, rigidbody.velocity.z);
			//transform.Translate(transform.right * moveSpeed * Time.deltaTime);
			goingRight = true;
		}
		else if(Input.GetAxisRaw("Horizontal") < 0)
		{
			if(goingRight)
				transform.eulerAngles = new Vector3(0,180,0);

			if(rigidbody.velocity.x > -maxVelocity)
				rigidbody.AddForce(moveForce * -Vector3.right, ForceMode.Impulse);
			else
				rigidbody.velocity = new Vector3(-maxVelocity, rigidbody.velocity.y, rigidbody.velocity.z);
			//transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
			goingRight = false;
		}
	}

	void Jump()
	{
		if(Input.GetAxisRaw("Jump") > 0)
		{
			rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
			canJump = false;
		}
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.collider.tag == groundTag && c.contacts[0].point.y < transform.position.y)
		{
			canJump = true;
		}
	}

	/*void OnCollisionStay(Collision c)
	{
		if(c.collider.tag == groundTag && c.contacts[0].point.y < transform.position.y && canJump == false)
		{
			canJump = true;
		}
	}*/
}
