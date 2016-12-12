using UnityEngine;
using System.Collections;

public class SpawnPickup : MonoBehaviour {

	[SerializeField]
	public Transform[] pickupSpawns;
	public GameObject coin;

	// Use this for initialization
	void Start () {
		
		Spawn ();

	}

	void Spawn() {
		for (int i = 0; i < pickupSpawns.Length; i++) {
			int coinFlip = Random.Range (0, 2);
			if (coinFlip > 0) {
				Instantiate (coin, pickupSpawns [i].position, Quaternion.identity);
					}
		}//for
	}//Spawn
}


