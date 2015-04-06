using UnityEngine;
using System.Collections;

public class MouseButtonClick : MonoBehaviour {
	RaycastHit hit;
	Ray ray;
	string nom ;
	bool clickUnité;
	// Use this for initialization
	void Start () {
		clickUnité = false;
	}
	
	// Update is called once per frame
	void Update () {
		ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButtonDown (0)) {
				if(hit.collider.gameObject.name == "Unite(Clone)"){
					clickUnité = true;

				}
			}
		}
	}

	void OnGUI(){
		if (clickUnité) {
			if (GUI.Button (new Rect (100, 150, 100, 25), "Améliorer")) {
				clickUnité = false;
			}
		}
		}
}
