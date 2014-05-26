using UnityEngine;
using System.Collections;

public class DogControler : MonoBehaviour {
	internal float baseSpeed;
	//private TextMesh bScore;
	//public int speedper20score;
	public int HP;
	//	public int score = 0;
	//	public GUIText guiScore;
	
	internal Vector3 direction;
	// Use this for initialization
//	void Awake()
//	{
//		bScore.text = "Score :" + PlayerPrefs.GetInt ("Guitext");
//	}
	void Start () {
		int div = Bloodscript.score / 10;
		//baseSpeed += speedper20score * div;
		//direction = Vector3.up;
		int divide =(int)( Time.time / 5f);
		if(divide % 3 !=0)
			ChangeDirection ();
		else
			direction = Vector3.up;
//		if (div >= 1f)
//			baseSpeed = div + 0.5f;
//		else
//			baseSpeed = 2.5f;
		baseSpeed = 2.5f + div * 0.25f;

		print (baseSpeed);
		rigidbody2D.velocity = direction * baseSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (direction * baseSpeed * Time.deltaTime);
		//if (Bloodscript.score % 20 == 0)

		if(transform.position.y > 4f)
		{
			Bloodscript.bs.LoseLife();
			Destroy(this.gameObject);
		}
		if(transform.position.y<-9.3f)
		{
			Destroy(this.gameObject);
		}
		//transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -0.5f, 2f),Mathf.Clamp(transform.position.y,1.5f, 13.5f),Mathf.Clamp(transform.position.z,0.1f,1f));
		//if(transform.position.x >2.6f || transform.position.x <-2.2f)
			//ChangeDirection();

	}
	
	public void TouchBalloon()
	{
		if(HP>0)
			audio.Play();
		HP--;
		if (HP <= 0) 
		{
			//direction = -Vector3.up;
			rigidbody2D.gravityScale = 3f;
			Bloodscript.bs.AddScore();
			if(Bloodscript.score%30==0)
			{
//				Debug.Log ("spawn special");
				SpawnerScripts.ss.SpecialSpawn();
			}
			Destroy (transform.GetChild(0).gameObject);

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
