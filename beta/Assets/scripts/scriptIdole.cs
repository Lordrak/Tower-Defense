using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class scriptIdole : MonoBehaviour {

	[SerializeField]
	GameObject _map;

	[SerializeField]
	public int _vie;


	[SerializeField]
	Vector3 vec;

	[SerializeField]
	Camera camHUD;

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
		Text[] guiText = camHUD.GetComponentsInChildren<Text> ();
		guiText [2].text = "HP: "+_vie;
	}

	public int getVie()
	{
		return _vie;
	}
	


}
