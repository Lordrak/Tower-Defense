using UnityEngine;
using System.Collections;

public class createobject : MonoBehaviour {

	[SerializeField]
	Transform testobject;

	[SerializeField]
	Transform plan;

	bool cheminTouche;
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
		Vector3 vec = new Vector3(hit.point.x, hit.point.y, hit.point.z);
		if (!cheminTouche){
			Instantiate (testobject, vec, Quaternion.identity);
		}
	}		
}
	
}