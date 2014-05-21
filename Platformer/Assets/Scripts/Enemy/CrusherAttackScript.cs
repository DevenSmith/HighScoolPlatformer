using UnityEngine;
using System.Collections;

public class CrusherAttackScript : MonoBehaviour 
{
	public GameObject Parent;

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player" && Parent.rigidbody.velocity.y < 0)
		{
			c.gameObject.SendMessage("Hurt", 9001, SendMessageOptions.DontRequireReceiver);
		}
	}
}
