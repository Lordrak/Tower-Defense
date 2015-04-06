using UnityEngine;
using System.Collections;

public class PowerSolo : MonoBehaviour {

	GameObject[] groupmob;
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			PowerActiveHades();
		}
		if (Input.GetKeyDown ("b")) {
			PowerBoostHades();
		}
	}
	
	void PowerActiveHades() {
		groupmob = GameObject.FindGameObjectsWithTag ("Adversaire");
		foreach (GameObject ch in groupmob) {
			if (ch.activeInHierarchy == true) {
				ch.GetComponent<Adversaire>().setVie(2);
				float speed  = ch.GetComponent<NavMeshAgent>().speed;
				hadesstop(ch);
				//ch.GetComponent<NavMeshAgent>().speed = speed;
				Debug.Log(ch.GetComponent<Adversaire>().getVie());
			}
		}
		
	}
	IEnumerator hadesstop(GameObject mob)
	{	
		int i = 0;
		while (i <2) {
			mob.GetComponent<NavMeshAgent> ().speed = 0;
			mob.GetComponent<NavMeshAgent> ().acceleration = 0;
			yield return new WaitForSeconds (1000f);
			i++;
		}
	}
	
	void PowerBoostHades() {
		var tours = Wave.getlestourelles ();
		foreach (GameObject tr in tours) {
			tr.GetComponent<Unité>().setDegat(2);
			tr.GetComponent<Unité>().setactivehades();
		}
		
	}
}