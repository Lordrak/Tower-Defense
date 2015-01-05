using UnityEngine;
using System.Collections;

public class scriptIdole : MonoBehaviour {

	[SerializeField]
	GameObject _map;

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
			_map.GetComponent<WaveSpawnScript>().recupereMort(other.GetComponent<Adversaire>().getNom());
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
		GUI.Label(new Rect(300,100,100,25),"point de vie : "+_vie);
	}


}
