using UnityEngine;
using System.Collections;

public class PowerUpDrop : MonoBehaviour 
{
	public GameObject[] powerUps;//healthkit / speed / star
	public float healthKitDropChance = .33f;
	public float speedDropChance = .2f;
	public float starChance = .05f;
	
	public void DropPowerUp()
	{
		float random = Random.Range(0.0f, 1.0f);
		if(random < healthKitDropChance)
		{
			Instantiate(powerUps[0], transform.position, powerUps[0].transform.rotation);
		}
		else
		{
			random = Random.Range(0.0f, 1.0f);
			if(random < speedDropChance)
				Instantiate(powerUps[1], transform.position, powerUps[1].transform.rotation);
			else
			{
				random = Random.Range(0.0f, 1.0f);
				if(random < starChance)
					Instantiate(powerUps[2], transform.position, powerUps[2].transform.rotation);
			}
		}
	}
}
