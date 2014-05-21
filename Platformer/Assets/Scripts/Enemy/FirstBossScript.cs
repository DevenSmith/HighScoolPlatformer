using UnityEngine;
using System.Collections;

public class FirstBossScript : EnemyScript 
{
	GameObject player;
	public float knockbackForce = 3.0f;
	public float knockupForce = 3.0f;
	public float hitDelay = .25f;
	float curHitDelay = 0.0f;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		curHitDelay -= Time.deltaTime;
	}

	public override void Hurt (int damage)
	{
		if(curHitDelay <= 0.0f)
		{
			curHitDelay = hitDelay;
			base.Hurt (damage);
			//print(health);
			if(player.transform.position.x < transform.position.x)
			{
				rigidbody.AddForce(	
				                   (transform.right* knockbackForce) 
				                   + (transform.up * knockupForce),
									ForceMode.Impulse);
			}
			else
			{
				rigidbody.AddForce(	
				                   (-transform.right* knockbackForce) 
				                   + (transform.up * knockupForce),
				                   ForceMode.Impulse);
			}
		}
	}
}
