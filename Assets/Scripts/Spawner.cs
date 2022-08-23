using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float figureSpawnRate = 1f;

	public GameObject[] allFiguresToSpawn = new GameObject[4];

	private float figureSpawnTimer = 0f;


	public float buffSpawnRate = 5f;

	public GameObject[] buffsToSpawn = new GameObject[2];

	private float buffSpawnTimer = 0f;

	// Update is called once per frame
	void Update()
    {
		if (Time.time >= figureSpawnTimer)
		{
			int indexSpawn = Random.Range(0, allFiguresToSpawn.Length);
			Instantiate(allFiguresToSpawn[indexSpawn], Vector3.zero, Quaternion.identity);
			figureSpawnTimer = Time.time + 1f / figureSpawnRate;
		}

		if(Time.time >= buffSpawnTimer)
		{
			int indexSpawn = Random.Range(0, buffsToSpawn.Length);
			Instantiate(buffsToSpawn[indexSpawn], Vector3.up * 5f, Quaternion.identity);
			buffSpawnTimer = Time.time + 1f / buffSpawnRate;
		}
	}
}
