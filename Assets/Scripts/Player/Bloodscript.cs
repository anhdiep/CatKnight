using UnityEngine;
using System.Collections;

public class Bloodscript : MonoBehaviour 
{
	private int blood = 3;
	public static int score;
	public static Bloodscript bs;
	public GameObject[] lives;
	public AudioSource bgmusic;
	public AudioClip gameOver;
	bool paused = false;
	public GameObject pauseButton;
	public GameObject pauseMenu;
	public GameObject BgScore;
	//public static int Counter = 0;
	public GUIText gameScore;
	public GUIText currentScore;
	public GUIText highScore;

	void Start()
	{
		//tao 3 cuc mau
		blood = 3;
		bs = this;
		for(int i=0;i<lives.Length;i++)
		{
			lives[i].SetActive(true);
		}
		score = 0;
		Time.timeScale = 1;
	}
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			//Bắt sự kien touch
	//		Collider2D col = Physics2D.OverlapPoint(Input.GetTouch(0).position.x,Input.GetTouch (0).position.y));
		//	Collider2D col = Physics2D.OverlapCircle(new Vector2(Input.mousePosition.x,Input.mousePosition.y),0.5f,1<<8);
			RaycastHit2D col = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
			if(col.collider!=null)
			{
				//Debug.Log ("Touch smt");
				if(col.collider.CompareTag("Bong"))
				{
					col.collider.GetComponent<TouchBong>().OnMouseEnter();
				}

			}
		}
	}

	IEnumerator pause(){
		yield return new WaitForSeconds (0.1f);
		paused = true;
		Time.timeScale = 0;
	}
	public void LoseLife()
	{
		//máu khi cho bay lên
		blood--;
		audio.Play ();
		switch(blood)
		{
		case 2:
			lives[2].SetActive(false);
			break;
		case 1:
			lives[1].SetActive(false);
			break;
		case 0:
			EndGame();
			break;

		}
	}
	public void AddScore()
	{
		score ++;
		gameScore.text = "" + score;
	}
	public void PauseBGMusic()
	{
		bgmusic.clip = gameOver;
		bgmusic.PlayOneShot (gameOver);
	}
	public void EndGame()
	{
		PauseBGMusic();
		lives[0].SetActive(false);
		Time.timeScale = 0;
		pauseButton.SetActive (false);
		pauseMenu.SetActive(true);
		BgScore.SetActive(true);
		currentScore.text = "Score: " + score;
		if(score>PlayerPrefs.GetInt ("Score"))
		{
			PlayerPrefs.SetInt("Score",score);
		}
		highScore.text = "Score: " + PlayerPrefs.GetInt ("Score");
		PlayerPrefs.Save ();
	}
}
