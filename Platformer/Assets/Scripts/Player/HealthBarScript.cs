using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour 
{
	public Transform target;
	public float xOffset;
	public float yOffset;

	float maxHealth;
	float healthPercent;
	PlayerScript playerScript;

	// Use this for initialization
	void Awake () 
	{
		playerScript = target.gameObject.GetComponent<PlayerScript>();
		maxHealth = playerScript.health;
		healthPercent = playerScript.health / maxHealth; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthPercent = playerScript.health / maxHealth;
		if(healthPercent > 0)
			transform.localScale = new Vector3 (healthPercent, 1, 1);
		else
			transform.localScale = new Vector3 (0, 1, 1);
		transform.position = new Vector3(target.position.x + xOffset, 
		                                 target.position.y + yOffset,
		                                 target.position.z);
	}
}
