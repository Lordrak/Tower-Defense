using UnityEngine;
using System.Collections;

public class createobject : MonoBehaviour {

	[SerializeField]
	Transform testobject;

	Ray ray;
		RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("a")) {
			ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray,out hit))
			{
				
				if(Input.GetKey(KeyCode.Mouse0))
				{
					Instantiate (testobject, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
				}
		}
	
}
/*public void createcube()
	{
			
		}*/
}
}