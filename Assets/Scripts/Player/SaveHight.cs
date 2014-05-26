using UnityEngine;
using System.Collections;

public class SaveHight : MonoBehaviour {public static int Counter = 0;
	void Update()
	{
		guiText.text = "" + Counter;
		if (Counter > PlayerPrefs.GetInt ("Guitext")) {
			PlayerPrefs.SetInt("Guitext", Counter);
				}
	}

}
