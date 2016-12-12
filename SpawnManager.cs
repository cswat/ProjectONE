using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	[SerializeField]
	public int maxPlatforms = 20;
	[SerializeField]
	public float horizontalMin = 6.5f;
	[SerializeField]
	public float horizontalMax = 14f;
	[SerializeField]
	public float VerticalMin = -6f;
	[SerializeField]
	public float VerticalMax = 6f;
	[SerializeField]

	public GameObject platform;

	private Vector2 originPosition;

	// Use this for initialization
	void Start () {
	
		originPosition = transform.position;
		Spawn ();
	}

	void Spawn() {
	
		for (int i = 0; i < maxPlatforms; i++)
		{
			Vector2 randomPosition = originPosition + new Vector2 (Random.Range(horizontalMin,horizontalMax),Random.Range(VerticalMin, VerticalMax));
			Instantiate(platform, randomPosition, Quaternion.identity);
			originPosition = randomPosition;
		}
	}
}
