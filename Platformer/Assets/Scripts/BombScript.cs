using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour 
{
	GameObject player;
	public float proximityRange = 2.5f;
	public int damage = 10;
	public float pushForce = 10;
	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () 
	{
		if(Vector3.Distance(transform.position, player.transform.position)
		   <= proximityRange)
		{
			player.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			Vector3 pushVector = player.transform.position - transform.position;
			pushVector = new Vector3(pushVector.x, pushVector.y, 0);
			player.rigidbody.AddForce(pushVector.normalized * pushForce,
			                          ForceMode.VelocityChange);
			Destroy(gameObject);
		}
	}
}
