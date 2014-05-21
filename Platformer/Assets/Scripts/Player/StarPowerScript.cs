using UnityEngine;
using System.Collections;

public class StarPowerScript : MonoBehaviour {

	public string[] enemyStrings;
	public int damage = 1000;
	
	
	void OnTriggerEnter(Collider c)
	{
		foreach(string s in enemyStrings)
		{
			if(c.tag == s )
			{
				c.SendMessage("Hurt",
				              damage, 
				              SendMessageOptions.DontRequireReceiver);
				//gameObject.SetActive(false);
			}
		}
	}
}
