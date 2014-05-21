using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour 
{
	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			PlayerScript.checkPoint = c.transform.position;
			Destroy(gameObject);
		}
	}
}
