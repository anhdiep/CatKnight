using UnityEngine;
using System.Collections;

public class DogControler : MonoBehaviour {
	internal float baseSpeed;
	float fixedSpeed;
	public int HP;
	bool isSpawn4; //bien nay xac dinh xem co phai no la may con thuoc spawn4 ko
	public bool redballoon;
	internal Vector3 direction;
	void Start () {
		//Tang Speed theo điểm
		int div = Bloodscript.score / 10;
		int divide =(int)( Time.time / 5f);
		if(divide % 3 !=0)
			ChangeDirection ();
		else
			direction = Vector3.up;
		//random ra 1 bien , neu bien nho hon xx thi con nay se chay nhanh vl
		if(!isSpawn4)
		{
			if(redballoon)
			{
				int rnd = Random.Range (0, 100);
				if(rnd<10)
					baseSpeed = 2.5f + div *0.25f + 3f;
				else
					baseSpeed = 2.5f + div *0.2f;
			}
			else
				baseSpeed = 2.5f + div *0.2f;
		}
		else
		{

			baseSpeed = 2.5f + div * 0.2f+ fixedSpeed;
		}
		print (baseSpeed);
		rigidbody2D.velocity = direction * baseSpeed;


	}

	void Update () {
		//transform.Translate (direction * baseSpeed * Time.deltaTime);
		//if (Bloodscript.score % 20 == 0)
		//Chạy theo tọa độ
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
		//Khi dạt diem 30 ra bong 3 quả
		if(HP>0)
			audio.Play();
		HP--;
		if (HP <= 0) 
		{
			//direction = -Vector3.up;
			rigidbody2D.isKinematic = false;
			rigidbody2D.gravityScale = 3f;
			GetComponent<CircleCollider2D>().isTrigger = true;
			Bloodscript.bs.AddScore();
			if(Bloodscript.score%30==0)
			{
//				Debug.Log ("spawn special");
				SpawnerScripts.ss.SpecialSpawn();
			}
//			if(Bloodscript.score%25==0)
//			{
//				SpawnerScripts.ss.SpecialSpawnCat();
//			}
			//xet khi nao diem chia het cho 15/ cu 15 diem thi se spawn 4 con 1 lan
			if(Bloodscript.score%20==0)
			{
				SpawnerScripts.ss.Spawn4();
			}
			if(Bloodscript.score%40==0)
			{
				SpawnerScripts.ss.SpawnCat();
			}
			if(Bloodscript.score%60==0)
			{
				SpawnerScripts.ss.SpawnBoss();
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
	public void FixedSpeed()
	{
		fixedSpeed = 0.5f;
		isSpawn4 = true;
	}
}
