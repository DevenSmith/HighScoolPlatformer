using UnityEngine;
using System.Collections;

public class ScoreGUIScript : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		guiText.text = "Score : " + GameManagerScript.score + "\n"
			+ "Lives : " + GameManagerScript.lives;
	}
}
