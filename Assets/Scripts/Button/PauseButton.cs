using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour 
{
	public GameObject pauseMenu;
	void OnMouseDown()
	{
		Time.timeScale = 0;
		pauseMenu.SetActive (true);
		gameObject.SetActive (false);
	}
}
