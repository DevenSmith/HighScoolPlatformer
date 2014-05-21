using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	public int health = 100;
	public int armour = 0;
	public int pointValue = 0;

	public virtual void Hurt(int damage)
	{
		if(damage > armour)
		{
			health -= damage - armour;
			if(health <= 0)
				Die ();
		}
	}

	public virtual void Die()
	{

		GameManagerScript.score += pointValue;
		gameObject.SendMessage("DropPowerUp", SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
