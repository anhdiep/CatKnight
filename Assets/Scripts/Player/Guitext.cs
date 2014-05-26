using UnityEngine;
using System.Collections;

public class Guitext : MonoBehaviour {
	public static int Counter = 0;
	void Update()
	{
		guiText.text = "" + Counter;
	}
}
