using UnityEngine;
using System.Collections;

public class ViewHightScore : MonoBehaviour 
{
	void Awake()
	{
		guiText.text = "Score: " + PlayerPrefs.GetInt("Score");
	}
}
