using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
	public AudioSource sourceBackground;
	//public AudioClip audioDemo;
	public static void Create()
	{
		GameObject obj = (GameObject)GameObject.Instantiate(Resources.Load("AudioManager"));
		obj.name = "__AudioManager";
		DontDestroyOnLoad(obj);
	}
}