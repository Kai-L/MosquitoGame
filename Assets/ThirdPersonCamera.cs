using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public Vector3 originalPosition;
	public Vector3 closePosition;

	public float camSpeed;
	public float camMin;
	public float camMax;

	bool shouldMove;

	public float currentDistance;

	public Vector3 currentWall;

	void Start(){
		originalPosition = transform.localPosition;
	}

	void Update()
	{
		if (Vector3.Distance (transform.position, currentWall) > 20 && currentWall != Vector3.zero) {
			shouldMove = false;
		}

		if (shouldMove) {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, closePosition, camSpeed);
		} else {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, originalPosition, camSpeed);
		}
	}

	void OnTriggerEnter(Collider c) 
	{
		shouldMove = true;
		currentWall = c.transform.position;
	}
}
