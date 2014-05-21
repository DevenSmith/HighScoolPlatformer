using UnityEngine;
using System.Collections;

public class PlayerAttackScript : MonoBehaviour 
{
	public float attackTime = .5f;
	public float delayTime = .5f;
	public GameObject attackBox;

	float curAttackTime = 0.0f;
	float curDelayTime = 0.0f;

	// Update is called once per frame
	void Update () 
	{
		if(curAttackTime > 0.0f)
		{
			curAttackTime -= Time.deltaTime;
			if(curAttackTime <= 0.0f)
				attackBox.SetActive(false);
		}
		if(curDelayTime > 0.0f)
			curDelayTime -= Time.deltaTime;

		if(Input.GetAxisRaw("Fire1") > 0.0f)
		{
			attackBox.SetActive(true);
			curDelayTime = delayTime + attackTime;
			curAttackTime = attackTime;
		}

	}
}
