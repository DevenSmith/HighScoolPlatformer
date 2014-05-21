using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public int health = 100;
	public int armour = 0;
	public string levelName = "main";
	public string gameOverName = "GameOver";

	public static Vector3 checkPoint;

	void Start()
	{
		if(checkPoint != Vector3.zero)
			transform.position = checkPoint;
	}

	void Hurt(int damage)
	{
		if(damage > armour)
		{
			health -= damage - armour;
			if(health <= 0)
				Die();
		}
	}

	public void Die()
	{
		GameManagerScript.lives --;
		if(GameManagerScript.lives <= 0)
		{
			GameManagerScript.score = 0;
			GameManagerScript.lives = 3;
			Application.LoadLevel(gameOverName);
		}
		else
			Application.LoadLevel(levelName);
	}
}
