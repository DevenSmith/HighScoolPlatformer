using UnityEngine;
using System.Collections;

public class BossAttackScript : MonoBehaviour 
{
	GameObject player;
	public GameObject bossBulletPrefab;
	public float fireRatePerSecond = 1.0f;
	float shotDelay = 1.0f;
	float curShotDelay = 1.0f;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		shotDelay = shotDelay/fireRatePerSecond;
		if(shotDelay < .01f)
			shotDelay = .01f;
	}

	void Update () 
	{
		curShotDelay -= Time.deltaTime;
		if(curShotDelay <= 0.0f)
		{
			Shoot();
			curShotDelay = shotDelay;
		}
	}

	public void Shoot()
	{
		transform.LookAt(player.transform);
		Instantiate(bossBulletPrefab, transform.position, transform.rotation);
	}
}
