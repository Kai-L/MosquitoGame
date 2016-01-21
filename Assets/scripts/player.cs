using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public GameObject mosquito;
	public float viewDistance;
	public static bool isHit;

	//private bool seen;

	void OnGUI(){
		if (isHit == true) {
		GUI.Label(new Rect(Screen.height-10,Screen.width-40,20,80),"You WIN!");
		}
	}

	// Use this for initialization
	void Start () {
		isHit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
		RaycastHit hit;
			Ray viewingRay = Camera.main.ScreenPointToRay(Input.mousePosition);

			//Debug.DrawRay (transform.position, Vector3.forward * viewDistance);

			if (Physics.Raycast (viewingRay, out hit, viewDistance)) {
				if (hit.collider.tag == "mosquito") {
					//seen = true;
					Debug.Log ("hit");
					isHit = true;
				}
			}
		}
	}
}
