using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {


		public float panSpeed = 4.0f; 

		private Vector3 mouseOrigin; 

		private bool isPanning; 

	

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (1)) {
			mouseOrigin = Input.mousePosition;
			isPanning = true; 	
		}

		if (Input.GetAxis("Mouse ScrollWheel")> 0){    // forward
			if (Camera.main.orthographicSize>20){
				Camera.main.orthographicSize-=3;
			}
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0){    // forward
			if (Camera.main.orthographicSize<50){
				Camera.main.orthographicSize+=3;
			}
		}


		if (!Input.GetMouseButton(1)){
			isPanning=false; 
		}

		// Move the camera on it's XY plane
		if (isPanning)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
			transform.Translate(move, Space.Self);
		} 
	}
}
