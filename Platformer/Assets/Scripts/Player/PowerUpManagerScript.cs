using UnityEngine;
using System.Collections;

public class PowerUpManagerScript : MonoBehaviour 
{
	public float speedTime = 7.5f;
	float curSpeedTime = 0.0f;
	bool speedPowerActive = false;
	public GameObject starPower;
	public bool starPowerActive = false;
	public float starPowerTime = 10.0f;
	float curStarPowerTime = 0.0f;
	float originalMaxVelocity;

	void Start()
	{
		CharacterMovementScript cms;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		cms = player.GetComponent<CharacterMovementScript>();
		originalMaxVelocity = cms.maxVelocity;
	}

	// Update is called once per frame
	void Update () 
	{
		if(starPowerActive)
		{
			curStarPowerTime -= Time.deltaTime;
			if(curStarPowerTime <= 0.0f)
				DeactiveStarPower();
		}

		if(speedPowerActive)
		{
			curSpeedTime -= Time.deltaTime;
			if(curSpeedTime <= 0)
				DeactivateSpeedPower();

		}
	}

	public void ActivateSpeedPower()
	{
		speedPowerActive = true;
		curSpeedTime = speedTime;
		CharacterMovementScript cms;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		cms = player.GetComponent<CharacterMovementScript>();
		if(cms.maxVelocity == originalMaxVelocity)
			cms.maxVelocity *= 2;
	}

	public void DeactivateSpeedPower()
	{
		speedPowerActive = false;
		CharacterMovementScript cms;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		cms = player.GetComponent<CharacterMovementScript>();
		cms.maxVelocity = originalMaxVelocity;
	}

	public void ActivateStarPower()
	{
		starPowerActive = true;
		starPower.SetActive(starPowerActive);
		curStarPowerTime = starPowerTime;
	}

	void DeactiveStarPower()
	{
		starPowerActive = false;
		starPower.SetActive(starPowerActive);
	}
}
