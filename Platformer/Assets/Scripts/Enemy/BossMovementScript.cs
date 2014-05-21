using UnityEngine;
using System.Collections;

public class BossMovementScript : MonoBehaviour 
{
	public float moveForce = 1.0f;
	public float jumpForce = 5.0f;
	public float maxVelocity = 5.0f;
	public float xJumpBuffer = 3.0f;
	public float yJumpBuffer = 1.0f;
	public float maxYJumpBuffer = 20.0f;
	public float zPosition;
	bool canJump = true;

	GameObject player;

	void Awake ()
	{
		zPosition = transform.position.z;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () 
	{
		Movement();
		transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
	}

	void Movement()
	{
		if(player.transform.position.x < transform.position.x)
		{
			if(rigidbody.velocity.x > -maxVelocity)
			{
				rigidbody.AddForce
					(-transform.right * moveForce, ForceMode.Impulse);
			}
		}
		if(player.transform.position.x > transform.position.x)
		{
			if(rigidbody.velocity.x < maxVelocity)
			{
				rigidbody.AddForce
					(transform.right * moveForce, ForceMode.Impulse);
			}
		}

		if(player.transform.position.x > transform.position.x - xJumpBuffer &&
		   	player.transform.position.x < transform.position.x + xJumpBuffer &&
		   	 player.transform.position.y > transform.position.y + yJumpBuffer &&
		      player.transform.position.y < transform.position.y + maxYJumpBuffer &&
		   	   rigidbody.velocity.y <= 0.1f && canJump)
		{
			canJump = false;
			rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Ground")
		{
			if(c.gameObject.transform.position.y < transform.position.y)
				canJump = true;
		}

	}
}
