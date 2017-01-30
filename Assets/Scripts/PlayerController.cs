using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float SpeedPerInput = 50.0f;
	public float JumpForce = 100.0f;
	public float MaxSpeed = 15.0f;
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		//rb2d.AddForce(new Vector2(1000,0));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown("left") || Input.GetKeyDown("right")){
			if (rb2d.velocity.x < MaxSpeed) {
				rb2d.AddForce (Vector2.right * SpeedPerInput);
			}
		}

		if(Input.GetKeyDown("up")){
			rb2d.AddForce (Vector2.up * JumpForce);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		Win ();
	}

	void Win(){
		GameManager.LoadScene("SocialGame", "Finally ! Time to eat your sandwich!" +
            "\nMonitor : Now that we had fun, we need to find a place to sleep. See how the forest is bright ? It’s got to be a perfect place to set up camp. Chop chop ! " +
            "\nMonitor : Alright everyone, see how it was easy peasy lemon squeezy ! Go and get know each other but don’t stay up too late."+
            "\n\nTry to be friends with everyone by choosing the right answer. ");
	}
}
