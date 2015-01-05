using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public string IP = "127.0.0.1";
	public int Port = 25001;
	public int nb;
	public int lancer = 1;
	void Update(){
		
	}
	
	void OnGUI()
	{
		if (Network.peerType == NetworkPeerType.Disconnected) 
		{
			if(GUI.Button(new Rect(100,100,100,25), "Start Client"))
			{
				Network.Connect(IP,Port);
			}
			if(GUI.Button(new Rect(100,125,100,25), "Start Server"))
			{
				Network.InitializeServer(10,Port);
			}
		}
		else
		{
			if (Network.peerType == NetworkPeerType.Client){
				GUI.Label(new Rect(100,100,100,25),"Client");
				Debug.Log(""+Network.connections.Length);
				if(GUI.Button(new Rect(100,125,100,25),"Logout"))
				{
					Network.Disconnect(250);
				}
				if(Network.connections.Length >= 2)
				{
					Application.LoadLevel("terrain");
				}
			}
			if (Network.peerType == NetworkPeerType.Server)
			{
				GUI.Label(new Rect(100,100,100,25),"Server");
				GUI.Label(new Rect(100,125,100,25),"Connections : " + Network.connections.Length);
				nb = Network.connections.Length;

				if(nb >= 1){
					if(GUI.Button(new Rect(200,200,100,25),"Lancer"))
					{
						networkView.RPC ("changeLevel", RPCMode.All);;
					}
				}
				if(GUI.Button(new Rect(100,150,100,25),"Logout"))
				{
					Network.Disconnect(250);
				}
			}

		}
	}



	[RPC]
	void changeLevel(){
		Application.LoadLevel("terrain");

	}

	void OnConnectedToServer() {
		GUI.Label(new Rect(200,200,100,25),"Pret");
	}

}
