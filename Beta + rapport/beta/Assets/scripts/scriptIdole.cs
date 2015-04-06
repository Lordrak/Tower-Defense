using UnityEngine;
using System.Collections;

public class scriptIdole : MonoBehaviour {

	[SerializeField]
	GameObject _map;

	[SerializeField]
	public int _vie;

	[SerializeField]
	public Transform idole;

	GameObject god;

	string gods = "geb";

	[SerializeField]
	Vector3 vec;

	// Use this for initialization
	void Start () {
		god = GameObject.FindGameObjectWithTag ("God");

	}



	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Adversaire") {
			_vie = _vie - other.gameObject.GetComponent<Adversaire>().getDegat();
			_map.GetComponent<Wave>().recupereMort(other.GetComponent<Adversaire>().getNom());
			Destroy (other.gameObject);
		}
		if (_vie <= 0) {
			Debug.Log("Perdu");
			Application.LoadLevel("Defaite");
		}
		Debug.Log ("Vie de L'idole : "+_vie);
	}

	void OnGUI()
	{
		GUI.Label(new Rect(vec.x,vec.y,vec.z,25),"point de vie : "+_vie);
	}

	public int getVie()
	{
		return _vie;
	}


	


}
