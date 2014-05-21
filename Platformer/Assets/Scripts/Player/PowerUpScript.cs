using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour 
{
	public bool isStarPowerUp = false;
	public bool isSpeedPowerUp = false;
	public bool isHealthKit = false;
	public string playerTag = "Player";
	public int healValue = 25;
	
	void OnTriggerEnter(Collider c)
	{
		if(c.tag == playerTag)
		{
			if(isStarPowerUp)
				c.gameObject.SendMessage
				("ActivateStarPower", SendMessageOptions.DontRequireReceiver);
			if(isSpeedPowerUp)
				c.gameObject.SendMessage
					("ActivateSpeedPower", SendMessageOptions.DontRequireReceiver);
			if(isHealthKit)
			{
				PlayerScript playerScript;
				playerScript = c.gameObject.GetComponent<PlayerScript>();
				
				playerScript.health += healValue;
				
				if(playerScript.health > 100)
				{
					playerScript.health = 100;
				}
			}

			Destroy(gameObject);
		}
	}
}
