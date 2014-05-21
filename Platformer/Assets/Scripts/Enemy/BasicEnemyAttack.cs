using UnityEngine;
using System.Collections;

public class BasicEnemyAttack : MonoBehaviour 
{
	public int damage = 25;
	public string playerTag = "Player";

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == playerTag)
		{
			c.gameObject.SendMessage
			   ("Hurt", damage, SendMessageOptions.DontRequireReceiver);
		}
	}
}
