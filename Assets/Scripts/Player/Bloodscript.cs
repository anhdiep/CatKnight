using UnityEngine;
using System.Collections;

public class Bloodscript : MonoBehaviour 
{
	public static int score = 3;
	public GameObject[] lives;
	//	public static int Counter = 0;
	//	public GUIText guiScore;
	bool paused = false;
	public GameObject pauseButton;
	public GameObject pauseMenu;

	void Start()
	{
		score = 3;
		for(int i=0;i<lives.Length;i++)
		{
			lives[i].SetActive(true);
		}
		Time.timeScale = 1;
	}
	void Update()
	{
		//			Counter += 1;
		//			guiScore.text = "Score: " + Counter;
	//	Debug.Log (score);
		switch(score)
		{
		case 2:
			lives[2].SetActive(false);
			break;
		case 1:
			lives[1].SetActive(false);
			break;
		case 0:
			lives[0].SetActive(false);
			//paused = true;
			Time.timeScale = 0;
			//StartCoroutine(pause());
			pauseButton.SetActive(false);
			pauseMenu.SetActive(true);
			break;

			//Application.LoadLevel ("KinghtCat");
		}
		
		
	}
	IEnumerator pause(){
		yield return new WaitForSeconds (0.5f);
		paused = true;
		Time.timeScale = 0;
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
