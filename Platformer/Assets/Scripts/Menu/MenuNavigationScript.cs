using UnityEngine;
using System.Collections;

public class MenuNavigationScript : MonoBehaviour 
{
	public GameObject[] options;
	public string[] destinations;
	int curSelection = 0;

	public KeyCode selectKey;
	public KeyCode navigateUpKey;
	public KeyCode navigateDownKey;
	
	void Start () 
	{
		transform.position = new Vector3( transform.position.x, options[0].transform.position.y, transform.position.z);
	}

	void Update () 
	{
		if(Input.GetKeyDown(selectKey))
		{
			if(curSelection == options.Length-1)
				Application.Quit();
			else
				Application.LoadLevel(destinations[curSelection]);
		}

		if(Input.GetKeyDown(navigateUpKey))
		{
			curSelection--;

			if(curSelection < 0)
				curSelection = options.Length-1;

			transform.position = new Vector3( transform.position.x, options[curSelection].transform.position.y, transform.position.z);
		}

		if(Input.GetKeyDown(navigateDownKey))
		{
			curSelection++;

			if(curSelection >= options.Length)
				curSelection = 0;

			transform.position = new Vector3( transform.position.x, options[curSelection].transform.position.y, transform.position.z);
		}
	}
}
