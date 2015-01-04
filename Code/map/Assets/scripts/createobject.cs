using UnityEngine;
using System.Collections;

public class createobject : MonoBehaviour {

	[SerializeField]
	Transform testobject;

	[SerializeField]
	Transform plan;

	Ray ray;
		RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
}
public void createcube()
	{
			ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray,out hit))
			{
				Vector3 vec = new Vector3(hit.point.x, hit.point.y, plan.position.z);
				vec.z = vec.z + 20;
				Instantiate (testobject, vec, Quaternion.identity);
				
			}		
}
	//void onCollisionenter(Collision other) 
	//{
		//if(other.gameObject.tag != "chemin" && other.gameObject.tag == "terrain")

		//}
}