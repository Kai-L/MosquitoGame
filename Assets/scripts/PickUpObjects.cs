using UnityEngine;
using System.Collections;

public class PickUpObjects : MonoBehaviour {
	GameObject grabbedObject;
	float grabbedObjectSize;
	bool grab = false;

	// Use this for initialization
	void Start () {
	
	}

	GameObject GetMouseHoverObject(float range){
		Vector3 position = gameObject.transform.position;
		RaycastHit raycastHit;
		Vector3 target = position + Camera.main.transform.forward * range;

		if (Physics.Linecast (position, target, out raycastHit))
			return raycastHit.collider.gameObject;
		return null;


	}

	void TryGrabObject(GameObject grabObject){
		if (grabObject == null)
			return;

		grabbedObject = grabObject;
		grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
	}

	void DropObject(){
		if (grabbedObject == null)
			return;
		grabbedObject = null;
	}
		


	// Update is called once per frame
	void Update () {
		Debug.Log (GetMouseHoverObject (5));

		if (gameObject.tag == "pickable") {
			if (Input.GetMouseButtonDown (1)) {
				TryGrabObject (GetMouseHoverObject (5));
				//grab = true;
			} else if (Input.GetMouseButtonDown (0)) {
				DropObject ();
			}
			
			if (grabbedObject != null) {
				Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
				grabbedObject.transform.position = newPosition;
			}
		}

	}
}
