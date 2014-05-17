using UnityEngine;
using System.Collections;

public class ResumeButton : MonoBehaviour {
	public GameObject pauseButton;
	public GameObject pauseMenu;
	void OnMouseDown()
	{
		Time.timeScale = 1;
		pauseButton.SetActive (true);
		pauseMenu.SetActive (false);
	}
}
