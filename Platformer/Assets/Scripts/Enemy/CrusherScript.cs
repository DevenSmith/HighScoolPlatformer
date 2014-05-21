using UnityEngine;
using System.Collections;

public class CrusherScript : MonoBehaviour 
{
	public bool isMovingCrusher = false;
	public float hoverHeight = 9.0f;
	public float dropTimer = 3.0f;
	public float riseForce = 1.0f;
	public float groundTime = 1.0f;

	float groundY = 0.0f;
	float curGroundTime = 0.1f;
	float curDropTime = 0.0f;

	public float moveSpeed = 3.0f;
	public string boundName = "CrusherBoundPrefab";
	
	void Start () 
	{
		curDropTime = dropTimer;
	}

	void Update () 
	{
		if(curDropTime > 0.0f)
		{
			if(isMovingCrusher)
				transform.Translate(transform.right*moveSpeed*Time.deltaTime);

			curDropTime -= Time.deltaTime;
			if(curDropTime <= 0.0f)
			{
				rigidbody.useGravity = true;
				curGroundTime = groundTime;
			}
		}
		else
		{
			if(rigidbody.velocity.y <= 0.2f && curGroundTime > 0)
			{
				curGroundTime -= Time.deltaTime;
				if(curGroundTime <= 0)
				{
					groundY = transform.position.y;
					rigidbody.useGravity = false;
					rigidbody.AddForce(transform.up * riseForce, ForceMode.Force);
				}
			}
			else
			{
				rigidbody.AddForce(transform.up * riseForce, ForceMode.Force);
				if(transform.position.y >= groundY + hoverHeight)
				{
					rigidbody.velocity = Vector3.zero;
					curDropTime = dropTimer;
					int rand = Random.Range(0, 2);
					if(rand == 0)
						moveSpeed *= -1;
				}
			}
		}
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.name == boundName)
		{
			//transform.Rotate(transform.up, 180);
			moveSpeed *= -1;
		}
	}
}
