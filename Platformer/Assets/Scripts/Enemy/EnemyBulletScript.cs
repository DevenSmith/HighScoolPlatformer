using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour 
{
	public int damage = 25;
	public string playerTag = "Player";
	public float lifeTime = 3.0f;
	public float moveSpeed = 5.0f;

	// Update is called once per frame
	void Update () 
	{
		lifeTime -= Time.deltaTime;
		if(lifeTime <= 0.0)
			Destroy(gameObject);
		transform.Translate(transform.right * moveSpeed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == playerTag)
		{
			c.gameObject.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}

	public void Hurt()
	{
		Destroy(gameObject);
	}
}
