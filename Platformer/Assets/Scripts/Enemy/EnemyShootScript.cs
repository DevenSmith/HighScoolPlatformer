using UnityEngine;
using System.Collections;

public class EnemyShootScript : MonoBehaviour 
{
	public GameObject bulletPrefab;
	public float shotsPerSecond;
	float shootTime;
	float curShootTime = 0.0f;
	public Transform shootPosition;

	// Use this for initialization
	void Start () 
	{
		shootTime = 1.0f / shotsPerSecond;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(curShootTime >= shootTime)
		{
			Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
			curShootTime -= shootTime;
		}
		curShootTime += Time.deltaTime;
	}
}
