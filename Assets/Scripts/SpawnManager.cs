using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject groundPrefab;
	public GameObject obstaclePrefab;
	public float startDelay = 2;
	
	// public Vector3 spawnPos = new Vector3(15,0.25f, 0);
	
	private bool isSpawn= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(!isSpawn)
		{
			SpawnObstacle();
			isSpawn= true;
			StartCoroutine("SpawnDelay");
		}
    }
	
	void SpawnObstacle()
	{
		// random pos
		Vector3 spawnPos = new Vector3(15, Mathf.RoundToInt(Random.Range(0, 3)), 0);
		// spawn
		GameObject ground= Instantiate(groundPrefab, spawnPos, groundPrefab.transform.rotation);
		GameObject obstacle= Instantiate(obstaclePrefab, new Vector3(15+ Random.Range(4,10), spawnPos.y +1, 0), obstaclePrefab.transform.rotation);
		// random scale
		ground.transform.localScale = new Vector3(Mathf.RoundToInt(Random.Range(2,8)), 1, 1);
	}
	
	IEnumerator SpawnDelay()
	{
		float spawnInterval = Random.Range(0.8f, 1.5f);
		yield return new WaitForSeconds(spawnInterval);
		isSpawn= false;
	}
}
