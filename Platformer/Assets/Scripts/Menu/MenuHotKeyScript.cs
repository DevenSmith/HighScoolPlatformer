using UnityEngine;
using System.Collections;

public class MenuHotKeyScript : MonoBehaviour 
{
	public KeyCode playKey;
	public KeyCode instructionsKey;
	public KeyCode creditsKey;
	public KeyCode exitKey;
	public KeyCode menuKey;

	public string menuName;
	public string levelOneName;
	public string instructionsName;
	public string creditsName;
	
	void Update () 
	{
		if(Input.GetKeyDown(menuKey))
			Application.LoadLevel(menuName);
		if(Input.GetKeyDown(playKey))
			Application.LoadLevel(levelOneName);
		if(Input.GetKeyDown(instructionsKey))
			Application.LoadLevel(instructionsName);
		if(Input.GetKeyDown(creditsKey))
			Application.LoadLevel(creditsName);
		if(Input.GetKeyDown(exitKey))
			Application.Quit();
	}
}
