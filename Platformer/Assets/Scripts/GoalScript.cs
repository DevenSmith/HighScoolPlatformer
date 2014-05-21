using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour 
{
	public string nextLevelName = "main";
	public string playerTag = "Player";

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == playerTag)
		{
			Application.LoadLevel(nextLevelName);
		}
	}
}
