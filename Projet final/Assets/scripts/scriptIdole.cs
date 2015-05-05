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

	int vieServer;
	int vieClient;
	int vieAdv;

	string gods = "geb";

	[SerializeField]
	Vector3 vec;

	// Use this for initialization
	void Start () {	

		god = GameObject.FindGameObjectWithTag ("God");
		if (PlayerPrefs.GetString ("GodChoosen") == "Geb") 
		{
			_vie = _vie + 5;
		}
		vieClient = _vie;
		vieServer = _vie;
		if (Network.peerType != NetworkPeerType.Disconnected) {
			networkView.RPC ("vieIdole", RPCMode.All);
		}
		if (Network.peerType == NetworkPeerType.Client) {
			vieServer = vieAdv;
		}
		if (Network.peerType == NetworkPeerType.Server) {
			vieClient = vieAdv;
		}	
	}



	// Update is called once per frame
	void Update () {
		if (Network.peerType == NetworkPeerType.Client) {
			vieServer = vieAdv;

		}
		if (Network.peerType == NetworkPeerType.Server) {
			vieClient = vieAdv;

		}	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Adversaire") {
			_vie = _vie - other.gameObject.GetComponent<Adversaire>().getDegat();		
			if (Network.peerType == NetworkPeerType.Disconnected) 
			{
				_map.GetComponent<Wave>().recupereMort(other.GetComponent<Adversaire>().getNom());
			}
			else{
				networkView.RPC ("vieIdole", RPCMode.All);
				_map.GetComponent<WaveSpawnScript>().recupereMort(other.GetComponent<Adversaire>().getNom());
			}
			Destroy (other.gameObject);
		}
		if (_vie <= 0) {
			Debug.Log("Perdu");
			Application.LoadLevel("Defaite");
		}

	}

	void OnGUI()
	{
			GUI.Label (new Rect (300, 100, 50, 100), "point de vie: " + _vie);
	}

	public int getVie()
	{
		return _vie;
	}

	[RPC]
	void vieIdole(){
		vieAdv = _vie;
	}
	


}
