using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
	public string direction;
	public float speed = 6.0f;
	public GameObject marker;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(Vector3.down * Time.deltaTime*speed);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Destroyer")
			Destroy (gameObject);
		if(other.tag == "ItemToFind"){
			if (Input.GetKeyDown (direction)) {
				transform.localScale = transform.localScale*2;
				StartCoroutine(FadeTo(0.0f, 0.2f));
				//Destroy (gameObject);
				RythmManager.SetScore (RythmManager.GetScore() + 10);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.tag == "ItemToFind"){
			if (Input.GetKeyDown (direction)) {
				transform.localScale = transform.localScale*2;
				StartCoroutine(FadeTo(0.0f, 0.2f));
				//Destroy (gameObject);
				RythmManager.SetScore (RythmManager.GetScore() + 10);
			}
		}
	}

	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = GetComponent<Renderer>().material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			GetComponent<Renderer>().material.color = newColor;
			yield return null;
		}

	}
}
