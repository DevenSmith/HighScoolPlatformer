using UnityEngine;
using System.Collections;

public class DropAwayPlatform : MonoBehaviour 
{
	public float dropTime;
	bool dropping = false;

	void Update () 
	{
		if(dropping)
		{
			dropTime -=Time.deltaTime;
			if(dropTime <= 0)
			{
				rigidbody.useGravity = true;
				collider.enabled = false;
				foreach(Transform child in transform)
				{
					child.collider.enabled = false;
				}
			}

			if(transform.position.y < -25.0f)
				Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.transform.tag == "Player")
		{
			dropping = true;
		}
	}
}
