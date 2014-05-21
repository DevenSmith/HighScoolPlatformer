using UnityEngine;
using System.Collections;

public class WeakPointScript : MonoBehaviour 
{
	public GameObject weakPointOfObject;
	bool canBeHurt = true;
	public float invincibleTime = .1f;
	float curInvTime = 0.0f;

	void Update()
	{
		if(curInvTime > 0)
		{
			curInvTime -= Time.deltaTime;
			if(curInvTime <= 0)
				canBeHurt = true;
		}
	}

	public void Hurt(int damage)
	{
		if(canBeHurt)
		{
			curInvTime = invincibleTime;
			canBeHurt = false;
			weakPointOfObject.SendMessage("Hurt",
		                              damage,
		                              SendMessageOptions.DontRequireReceiver);
		}
	}
}
