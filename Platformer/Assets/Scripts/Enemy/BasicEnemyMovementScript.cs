using UnityEngine;
using System.Collections;

public class BasicEnemyMovementScript : MonoBehaviour 
{
	public float moveSpeed = 3.0f;
	public string boundName = "EnemyBoundPrefab";
	
	void Update () 
	{
		transform.Translate(transform.right*moveSpeed*Time.deltaTime);
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.name == boundName)
		{
			transform.Rotate(transform.up, 180);
			moveSpeed *= -1;
		}
	}

}
