using UnityEngine;
using System.Collections;

public class BossBulletScript : MonoBehaviour 
{
	public int damage = 10;
	public string playerTag = "Player";
	public float lifeTime = 3.0f;
	public float moveSpeed = 5.0f;

	void Update () 
	{
		rigidbody.AddForce(transform.forward *moveSpeed);
		lifeTime-= Time.deltaTime;
		if(lifeTime <= 0.0f)
			Hurt ();
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == playerTag)
		{
			c.gameObject.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			Hurt();
		}
	}

	public void Hurt()
	{
		Destroy(gameObject);
	}
}
