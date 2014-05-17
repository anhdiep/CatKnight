using UnityEngine;
using System.Collections;

public class DogControler : MonoBehaviour {
	public float baseSpeed =2;
	public int speedper20score;
	public int HP;
	//	public int score = 0;
	//	public GUIText guiScore;
	
	Vector3 direction;
	// Use this for initialization
	void Start () {
		int div = Guitext.Counter / 20;
		baseSpeed += speedper20score * div;
		//direction = Vector3.up;
		int divide =(int)( Time.time / 5f);
		if(divide % 2 !=0)
			ChangeDirection ();
		else
			direction = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * baseSpeed * Time.deltaTime);
		if(transform.position.y > 4f)
		{
			Bloodscript.score--;
			Destroy(this.gameObject);
		}
		if(transform.position.y<-9.3f)
		{
			Destroy(this.gameObject);
		}
		//transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -0.5f, 2f),Mathf.Clamp(transform.position.y,1.5f, 13.5f),Mathf.Clamp(transform.position.z,0.1f,1f));
		if(transform.position.x >2.6f || transform.position.x <-2.2f)
			ChangeDirection();
	}
	
	void OnMouseDown()
	{
		HP--;
		if (HP == 0) 
		{
			direction = -Vector3.up;
			Guitext.Counter += 1;
			if(Guitext.Counter==30)
			{
				Debug.Log ("spawn special");
				SpawnerScripts.ss.SpecialSpawn();
			}

		}
		//		guiScore.text = "Score: " + score;
		//AudioTouch.Create();
	}
	void ChangeDirection()
	{
		direction = new Vector3 (Random.Range (-1f, 1f), 1f, 0);
		direction.Normalize ();
	}
}
