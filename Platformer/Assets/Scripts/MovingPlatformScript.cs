using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour 
{
	public string platformBoundsTag = "PlatformBound";
	public float moveSpeed = 1.0f;
	
	void Update () 
	{
		transform.Translate(transform.right * moveSpeed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == platformBoundsTag)
		{
			moveSpeed *= -1;
		}
		else if(c.gameObject.tag == "Player")
		{
			c.gameObject.transform.parent = transform;
		}
	}

	void OnCollisionExit(Collision c)
	{
		if(c.gameObject.tag == "Player")
		{
			c.gameObject.transform.parent = null;
		}
	}
}
