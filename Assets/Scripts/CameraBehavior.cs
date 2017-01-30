using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	private Camera camera;
	private Vector3 offset;

	void Start(){
		camera = GetComponent<Camera> ();
		offset = transform.position - target.transform.position;
	}

	// Update is called once per frame
	/*void FixedUpdate () 
	{
		if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

	}*/

	void LateUpdate ()
	{
		if (target) {
			transform.position = new Vector3(target.transform.position.x + offset.x, 0.0f, target.transform.position.z + offset.z);
		}
	}
}
