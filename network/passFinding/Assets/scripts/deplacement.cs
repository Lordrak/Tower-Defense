using UnityEngine;
using System.Collections;

public class deplacement : MonoBehaviour {

	
	public string IP = "127.0.0.1";
	public int Port = 25001;
	public int nb;

	[SerializeField]
	NavMeshAgent _agent;

	[SerializeField]
	Transform _destination;

	// Use this for initialization
	void Start () {
		_agent.SetDestination(_destination.position);
	}

	void OnGUI(){
		if (Network.peerType == NetworkPeerType.Disconnected) {
			Application.LoadLevel ("MenuNetworking");
		} 
		else {
			if (Network.peerType == NetworkPeerType.Client) {
				GUI.Label (new Rect (100, 100, 100, 25), "Client");
			}
			else{
				GUI.Label (new Rect (100, 100, 100, 25), "Server");
			}
			if (GUI.Button (new Rect (100, 125, 100, 25), "Logout")) {
				Network.Disconnect (250);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
