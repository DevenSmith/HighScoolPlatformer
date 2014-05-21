using UnityEngine;
using System.Collections;

public class PlayerAttackBoxScript : MonoBehaviour 
{
	public string enemyString = "Enemy";
	public string[] enemyBulletStrings;
	public int damage = 100;


	void OnTriggerEnter(Collider c)
	{
		if(c.tag == enemyString )
		{
			c.SendMessage("Hurt",
			              damage, 
			              SendMessageOptions.DontRequireReceiver);
			gameObject.SetActive(false);
		}
		foreach(string s in enemyBulletStrings)
		{
			if(c.tag == s)
			{
				c.SendMessage("Hurt", SendMessageOptions.DontRequireReceiver);
				gameObject.SetActive(false);
			}
		}
	}
}
