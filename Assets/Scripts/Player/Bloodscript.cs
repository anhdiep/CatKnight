using UnityEngine;
using System.Collections;

public class Bloodscript : MonoBehaviour 
{
	private int score = 3;
	public static Bloodscript bs;
	public GameObject[] lives;
	public AudioSource bgmusic;
	public AudioClip gameOver;
	//	public static int Counter = 0;
	//	public GUIText guiScore;
	bool paused = false;
	public GameObject pauseButton;
	public GameObject pauseMenu;

	void Start()
	{
		score = 3;
		bs = this;
		for(int i=0;i<lives.Length;i++)
		{
			lives[i].SetActive(true);
		}
		Time.timeScale = 1;
	}
	IEnumerator pause(){
		yield return new WaitForSeconds (0.5f);
		paused = true;
		Time.timeScale = 0;
	}
	public void LoseLife()
	{
		score--;
		audio.Play ();
		switch(score)
		{
		case 2:
			lives[2].SetActive(false);
			break;
		case 1:
			lives[1].SetActive(false);
			break;
		case 0:
			PauseBGMusic();
			lives[0].SetActive(false);
			//paused = true;
			Time.timeScale = 0;
			//StartCoroutine(pause());
			pauseButton.SetActive(false);
			pauseMenu.SetActive(true);
			break;
		}
	}
	public void PauseBGMusic()
	{
//		bgmusic.clip = gameOver;
		bgmusic.PlayOneShot (gameOver);
	}
//	void OnGUI()
//	{
//		if (paused == true) {
//			
//			if(GUI.Button(new Rect(130,200,100,60),"Retry Game")){
//				Time.timeScale = 1;
//				Application.LoadLevel("CatKnight");
//				
//			}
//			if(GUI.Button(new Rect(130,300,100,60),"Quit Game"))
//			{
//				Application.Quit();
//			}
//		}
//		
//	}
}
