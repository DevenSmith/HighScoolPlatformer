using UnityEngine;
using System.Collections;

public class HealthKitScript : MonoBehaviour 
{
	public string playerTag = "Player";
	public int healValue = 25;

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == playerTag)
		{
			PlayerScript playerScript;
			playerScript = c.gameObject.GetComponent<PlayerScript>();

			playerScript.health += healValue;

			if(playerScript.health > 100)
			{
				playerScript.health = 100;
			}
			Destroy(gameObject);
		}
	}
}
