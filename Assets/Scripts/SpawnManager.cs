using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject groundPrefab;
	public GameObject obstaclePrefab;
	public GameObject obstacle2Prefab;
	public GameObject coinPrefab;



	// public Vector3 spawnPos = new Vector3(15,0.25f, 0);

	private bool isSpawn = false;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (!isSpawn)
		{
			SpawnObstacle();
			isSpawn = true;
			StartCoroutine("SpawnDelay");
		}
	}

	void SpawnObstacle()
	{
		// random pos
		Vector3 spawnPos = new Vector3(20, Mathf.RoundToInt(Random.Range(7, 12)), -8);
		// spawn
		GameObject ground = Instantiate(groundPrefab, spawnPos, groundPrefab.transform.rotation);
		int angkaProb = Random.Range(0, 3);
		int angkaProb2 = Random.Range(0, 5);
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


		// random scale
		ground.transform.localScale = new Vector3(Mathf.RoundToInt(Random.Range(2, 5)), 1, 1);
	}

	IEnumerator SpawnDelay()
	{
		float spawnInterval = Random.Range(1.0f, 2f);
		yield return new WaitForSeconds(spawnInterval);
		isSpawn = false;
	}
}
