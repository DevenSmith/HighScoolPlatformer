using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour 
{
	public GameObject trigger;

	// Update is called once per frame
	void Update () 
	{
		if(trigger == null)
		{
			//Destroy(gameObject);
			rigidbody.useGravity = true;
			collider.enabled = false;
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			Invoke("DestroyMySelf", 5.0f);
		}
	}

	void DestroyMySelf()
	{
		Destroy(gameObject);
	}
}
