using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {
	
	[SerializeField]
	Transform[] groupmob;
	
	[SerializeField]
	Transform ressource;
	
	int mana = 0;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Network.peerType != NetworkPeerType.Disconnected) {
			mana = ressource.GetComponent<WaveSpawnScript> ().getMana ();
		}
		else {
			mana = ressource.GetComponent<Wave> ().getMana ();
		}
		if (mana == 100){
			if (GUI.Button(new Rect(100, 100, 100, 25), "Pouvoir actif")) {
				if (PlayerPrefs.GetString("GodChoosen") == "Hades") {
					PowerActiveHades();
				}
				if (PlayerPrefs.GetString("GodChoosen") == "Zeus") {
					PowerActiveZeus();
				}
				if (PlayerPrefs.GetString("GodChoosen") == "Geb") {
					PowerActiveGeb();
				}
			}
			if (GUI.Button(new Rect(100, 150, 100, 25), "Pouvoir passif")) {
				if (PlayerPrefs.GetString("GodChoosen") == "Hades") {
					PowerBoostHades();
				}
				if (PlayerPrefs.GetString("GodChoosen") == "Zeus") {
					PowerBoostZeus();
				}
				if (PlayerPrefs.GetString("GodChoosen") == "Geb") {
					PowerBoostGeb();
				}
			}
		}
	}
	
	void PowerActiveHades() {
		foreach (Transform ch in groupmob) {
			if (ch && ch.gameObject.activeInHierarchy == true) {
				Debug.Log("POWA");
				ch.gameObject.GetComponent<Adversaire>().setVie(5);
				//Vector3 dest = ch.GetComponent<deplacement>().getDestination();
				//StartCoroutine(hadesstop(ch));
				//Debug.Log("marche");
				//ch.GetComponent<NavMeshAgent>().SetDestination(dest);
			}
		}
		
	}
	IEnumerator hadesstop(Transform mob)
	{
		int i = 0;
		bool test = true;
		while(test){
			if (i < 2) {
				Debug.Log(i);
				mob.GetComponent<NavMeshAgent> ().SetDestination (mob.position);
				i++;
				yield return new WaitForSeconds (2f);
			}
		}
	}
	
	void PowerBoostHades() {
		if (Network.peerType != NetworkPeerType.Disconnected) {
			var tours = WaveSpawnScript.getlestourelles ();
			foreach (GameObject tr in tours) {
				Debug.Log ("POWA");
				tr.GetComponent<NewBehaviourScript> ().setDegat (2);
				tr.GetComponent<NewBehaviourScript> ().setactivehades (true);
			}
		} 
		else {
			var tours = Wave.getlestourelles ();
			foreach (GameObject tr in tours) {
				Debug.Log ("POWA");
				tr.GetComponent<NewBehaviourScript> ().setDegat (2);
				tr.GetComponent<NewBehaviourScript> ().setactivehades (true);
			}	
		}
	}
	void PowerActiveGeb()
	{
		foreach (Transform ch in groupmob) {
			Debug.Log("check 2");
			if (ch && ch.gameObject.activeInHierarchy == true) {
				Debug.Log("POWA");
				ch.gameObject.GetComponent<Adversaire>().setVie(5);
				Debug.Log(ch.gameObject.GetComponent<Adversaire>().getVie());
			}
		}
	}
	void PowerBoostGeb() {
		if (Network.peerType != NetworkPeerType.Disconnected) {
			var tours = WaveSpawnScript.getlestourelles ();
			foreach (GameObject tr in tours) {
				Debug.Log ("POWA");
				tr.GetComponent<NewBehaviourScript> ().setDegat (4);
				tr.GetComponent<NewBehaviourScript> ().setactivegeb (true);
			}
		}
		else {
			var tours = Wave.getlestourelles ();
			foreach (GameObject tr in tours) {
				Debug.Log ("POWA");
				tr.GetComponent<NewBehaviourScript> ().setDegat (4);
				tr.GetComponent<NewBehaviourScript> ().setactivegeb (true);
			}
		}
	}
	void PowerActiveZeus() {
		Debug.Log("check 1");
		foreach (Transform ch in groupmob) {
			Debug.Log("check 2");
			if (ch && ch.gameObject.activeInHierarchy == true) {
				Debug.Log("POWA");
				ch.gameObject.GetComponent<Adversaire>().setVie(5);
				//ch.gameObject.GetComponent<NavMeshAgent>().speed = ch.gameObject.GetComponent<NavMeshAgent>().speed - 5 ;
				//ch.gameObject.GetComponent<NavMeshAgent>().acceleration = ch.gameObject.GetComponent<NavMeshAgent>().acceleration +10 ;
				
				//Debug.Log(ch.gameObject.GetComponent<Adversaire>().getVie());
			}
		}
	}
	void PowerBoostZeus() {
		if (Network.peerType != NetworkPeerType.Disconnected) {
			var tours = WaveSpawnScript.getlestourelles ();
			foreach (GameObject tr in tours) {
				Debug.Log ("POWA");
				tr.GetComponent<NewBehaviourScript> ().setDegat (2);
				tr.GetComponent<NewBehaviourScript> ().setactivezeus (true);
			}
		} 
		else {
			var tours = Wave.getlestourelles ();
			foreach (GameObject tr in tours) {
				Debug.Log ("POWA");
				tr.GetComponent<Unité> ().setDegat (2);
				tr.GetComponent<Unité> ().setactivezeus (true);
			}
		}
	}
}