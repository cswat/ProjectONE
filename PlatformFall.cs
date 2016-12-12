using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {
	[SerializeField]
	public float fallDelay = 2f;


	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
			Invoke ("Fall", fallDelay);
		
	}//OnCollisionEnter2D

	void Fall()
	{
		rb2d.isKinematic = false;
	}//fall
}
