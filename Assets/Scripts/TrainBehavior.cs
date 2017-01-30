using UnityEngine;
using System.Collections;

public class TrainBehavior : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float Speed = 5.0f;
	public float MaxSpeed = 14.0f;
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rb2d.velocity.x < MaxSpeed) {
			rb2d.AddForce (Vector2.right * Speed);
		}
	}
}
