using UnityEngine;
using System.Collections;

public class scriptIdole : MonoBehaviour {


	[SerializeField]
	public int _vie;


	[SerializeField]
	public GameObject _text;

	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Adversaire") {
			_vie = _vie - other.gameObject.GetComponent<Adversaire>().getDegat();
			Destroy (other.gameObject);
		}
		if (_vie <= 0) {
			Debug.Log("Perdu");
		}
		Debug.Log ("Vie de L'idole : "+_vie);
	}


}
