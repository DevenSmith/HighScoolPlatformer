using UnityEngine;
using System.Collections;

public class PitScript : MonoBehaviour 
{
	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			c.gameObject.SendMessage
				("Die", SendMessageOptions.DontRequireReceiver);
		}
		else if(c.tag == "Enemy")
		{
			Destroy(c.gameObject);
		}
	}
}
