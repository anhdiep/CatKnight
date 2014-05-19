using UnityEngine;
using System.Collections;

public class AudioTouch : MonoBehaviour {
	
	public AudioSource sourceBackground;
	public AudioClip audioDemo;
	public static void Create()
	{
		GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load("AudioTouch"));
		obj.name = "__AudioTouch";
		DontDestroyOnLoad(obj);
	}
}
