using UnityEngine;
using System.Collections;

public class StarPowerUpScript : MonoBehaviour 
{
	public string playerTag = "Player";

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == playerTag)
		{
			c.gameObject.SendMessage
				("ActivateStarPower", SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}
