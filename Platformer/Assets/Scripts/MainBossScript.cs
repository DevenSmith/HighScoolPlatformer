using UnityEngine;
using System.Collections;

public class MainBossScript : MonoBehaviour 
{
	public int health = 100;
	public int phase2Health = 50;
	bool isPhase2 = false;
	public GameObject[] crushers;
	public Material phase2Material;
	public GameObject weakPoint;
	public GameObject phase2Attack;
	public int scoreValue = 0;

	public void Hurt(int damage)
	{
		health -= damage;
		if(health <= phase2Health && !isPhase2)
		{
			isPhase2 = true;
			phase2Attack.SetActive(true);
			foreach(GameObject g in crushers)
			{
				renderer.material = phase2Material;
				g.SetActive(false);
			}
		}

		if(health <= 0)
		{
			Destroy(gameObject);
			GameManagerScript.score += scoreValue;
		}
	}
}
