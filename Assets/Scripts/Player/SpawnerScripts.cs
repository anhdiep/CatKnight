using UnityEngine;
using System.Collections;

public class SpawnerScripts : MonoBehaviour {
	
	public static SpawnerScripts ss;
	private float spawnTime;
	private float SpawnDelay;
	public GameObject[] meteors;
	public GameObject meteor_special;
	
	void Awake()
	{
		ss = this;
	}
	
	public void SpecialSpawn()
	{
		special_spawn = true;
		Invoke ("Offspecial", 3f);
	}
	void Offspecial()
	{
		special_spawn = false;
	}
	
	bool special_spawn;
	
	
	// Use this for initialization
	void Start () {
		spawnTime = Random.Range (1, 1);
		SpawnDelay = Random.Range (1, 2);
		CancelInvoke ("SpawnMeteors");
		InvokeRepeating ("SpawnMeteors", SpawnDelay, spawnTime);
	}
	// Update is called once per frame
	void SpawnMeteors()
	{
		if(!special_spawn)
		{
			Vector3 pos = transform.position;
			if(Guitext.Counter>=20)
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
		}
		
		
	}
}
