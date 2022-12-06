using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject groundPrefab;
	public GameObject obstaclePrefab;
	public GameObject obstacle2Prefab;
	public GameObject coinPrefab;
	private bool isSpawn = false;
	
	// Update is called once per frame
	void Update()
	{
		//Check if its not Spawn
		if (!isSpawn)
		{
			SpawnObstacle();
			isSpawn = true;
			StartCoroutine("SpawnDelay"); //mengatur delay dari spawn rintangan
		}
	}

	void SpawnObstacle()
	{
		// Random Position
		Vector3 spawnPos = new Vector3(20, Mathf.RoundToInt(Random.Range(7, 12)), -8);
		
		//Spawning Ground
		GameObject ground = Instantiate(groundPrefab, spawnPos, groundPrefab.transform.rotation);
		
		//Creating Randomizer and Spawning for Obstacle
		int angkaProb = Random.Range(0, 3); //mengatur model obstacle 1
		int angkaProb2 = Random.Range(0, 5); //mengatur model obstacle 2
		if (angkaProb == 1)
        {
			GameObject obstacle = Instantiate(obstaclePrefab, new Vector3(20 + Random.Range(1, 2), spawnPos.y + 0.3f, -8), obstaclePrefab.transform.rotation);
		}
		if (angkaProb2 == 1)
		{
			GameObject obstacle2 = Instantiate(obstacle2Prefab, new Vector3(30 + Random.Range(1, 2), spawnPos.y + 2f, -8), obstaclePrefab.transform.rotation);
		}
		if (angkaProb2 == 2)
		{
			GameObject obstacle2 = Instantiate(coinPrefab, new Vector3(20 + Random.Range(1, 5), spawnPos.y + Random.Range(1, 2), -8), obstaclePrefab.transform.rotation);
		}


		//Creating Random Scale
		ground.transform.localScale = new Vector3(Mathf.RoundToInt(Random.Range(2, 5)), 1, 1);
	}

	IEnumerator SpawnDelay()
	{
		//Spawning Delay for every object
		float spawnInterval = Random.Range(1.0f, 2f);
		yield return new WaitForSeconds(spawnInterval);
		isSpawn = false;
	}
}
