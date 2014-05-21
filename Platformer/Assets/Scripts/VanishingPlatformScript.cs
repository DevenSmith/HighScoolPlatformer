using UnityEngine;
using System.Collections;

public class VanishingPlatformScript : MonoBehaviour 
{
	public float onTime = 5.0f;
	public float offTime = 2.0f;
	float curOnTime = 0.0f;
	float curOffTime = 0.0f;
	public bool on = true;
	
	void Start () 
	{
		curOnTime = onTime;
	}

	void Update () 
	{
		if(on)
		{
			curOnTime -= Time.deltaTime;
			if(curOnTime <= 0.0f)
			{
				renderer.enabled = false;
				collider.enabled = false;
				on = false;
				curOffTime = offTime;
			}
		}
		else
		{
			curOffTime -= Time.deltaTime;
			if(curOffTime <= 0.0f)
			{
				renderer.enabled = true;
				collider.enabled = true;
				on = true;
				curOnTime = onTime;
			}
		}
	}
}
