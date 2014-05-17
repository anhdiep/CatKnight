using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour 
{
	void OnMouseDown()
	{
		Guitext.Counter = 0;
		Application.LoadLevel (0);
	}
}
