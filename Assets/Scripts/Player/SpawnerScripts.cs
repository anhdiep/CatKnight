using UnityEngine;
using System.Collections;
public class SpawnerScripts : MonoBehaviour {	
	public static SpawnerScripts ss;
	private float spawnTime;
	private float SpawnDelay;
	public GameObject[] meteors;
	public GameObject meteor_special;
	public GameObject meteor_specialcat;
	public GameObject meteor_boss;
	//public GameObject meteor_specialcat;
	
	void Awake()
	{
		ss = this;
	}
	public void SpecialSpawnCat()
	{
		special_spawncat = true;
		Invoke ("Offspecialcat", 3f);
	}
//	public void SpecialSpawnBoss()
//	{
//		special_spawnboss = true;
//		Invoke ("OffSpecialboss", 3f);
//	}
	public void SpawnCat()
	{
		for(int i =0;i<5;i++)
		{
			Vector3 v3 = transform.position;
			v3.y -= i;
			Instantiate(meteor_specialcat,v3,Quaternion.identity);
		}
	}
//	public void SpawnBoss()
//	{
//		for(int i =0; i<1; i++)
//		{
//			Vector3 v3 = transform.position;
//			v3.y-=i;
//			Instantiate(meteor_boss,v3,Quaternion.identity);
//		}
//	}
	public void SpecialSpawn()
	{

		special_spawn = true;
		Invoke ("Offspecial", 3f);
	}
	void Offspecialcat()
	{
		special_spawncat = false;
	}
//	void OffSpecialboss()
//	{
//		special_spawnboss = false;
//	}
	void Offspecial()
	{
		special_spawn = false;
	}
	
	bool special_spawn;
	bool special_spawncat;
//	bool special_spawnboss;
	
	
	// Use this for initialization
	void Start () 
	{
		spawnTime = Random.Range (1, 1);
		SpawnDelay = Random.Range (1, 2);
		CancelInvoke ("SpawnMeteors");
		InvokeRepeating ("SpawnMeteors", SpawnDelay, spawnTime);
	}
	// Update is called once per frame
	void SpawnMeteors()
	{
		//khi score = 20 sinh ra bong tim
		if (!special_spawn)
		{
			Vector3 pos = transform.position;
			if (Bloodscript.score >= 25) 
			{
				int meteorsIndex = Random.Range (0, meteors.Length);
				Instantiate (meteors [meteorsIndex], new Vector3 (pos.x + Random.Range (-2, 2), pos.y, pos.z), Quaternion.identity);
			}
			else 
			{ 
				Instantiate (meteors [0], new Vector3 (pos.x + Random.Range (-2, 2), pos.y, pos.z), Quaternion.identity);
			}
		} 

		else
		{
			Vector3 pos = transform.position;
			Instantiate (meteor_special, new Vector3 (pos.x + Random.Range (-2, 2), pos.y, pos.z), Quaternion.identity);
			//Instantiate (meteor_specialcat, new Vector3 (pos.x + Random.Range (-2, 2), pos.y, pos.z), Quaternion.identity);
		}
	}
	public void Spawn4()
	{
		Vector3 pos = transform.position;
		GameObject ref_go;
		for(int i=0;i<4;i++)
		{
			ref_go = (GameObject)Instantiate (meteors [0], new Vector3 (pos.x -2.1f + 1.5f*i, pos.y, pos.z), Quaternion.identity);
			ref_go.GetComponent<DogControler>().FixedSpeed();
		}
	}
	public void SpawnBoss()
	{
		//Debug.Log ("Spawn boss");
		Instantiate (meteor_boss, transform.position, Quaternion.identity);
	}

}
