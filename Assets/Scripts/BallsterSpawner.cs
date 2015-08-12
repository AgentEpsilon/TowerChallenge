using UnityEngine;
using System.Collections;

public class BallsterSpawner : MonoBehaviour {

	public GameObject monster;
	public float spawnDelay;
	private float timeSinceLastSpawn;

	// Use this for initialization
	void Start () {
		timeSinceLastSpawn = spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawn -= Time.deltaTime;
		if (timeSinceLastSpawn <= 0) {
			Instantiate(monster).transform.position = new Vector3(.5f, .5f, 2.5f);
			timeSinceLastSpawn = spawnDelay;
		}
	}
}
