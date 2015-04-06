using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {
	
	[SerializeField]
	Transform[] groupmob;
	
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
		Debug.Log("check 1");
		foreach (Transform ch in groupmob) {
			Debug.Log("check 2");
			if (ch.gameObject.activeInHierarchy == true) {
				Debug.Log("POWA");
				ch.gameObject.GetComponent<Adversaire>().setVie(2);
				float speed  = ch.GetComponent<NavMeshAgent>().speed;
				hadesstop(ch);
				//ch.GetComponent<NavMeshAgent>().speed = speed;
				Debug.Log(ch.gameObject.GetComponent<Adversaire>().getVie());
			}
		}
		
	}
	IEnumerator hadesstop(Transform mob)
	{	
		int i = 0;
		while (i <2) {
			mob.gameObject.GetComponent<NavMeshAgent> ().speed = 0;
			mob.gameObject.GetComponent<NavMeshAgent> ().acceleration = 0;
			yield return new WaitForSeconds (1000f);
			i++;
		}
	}
	
	void PowerBoostHades() {
		var tours = WaveSpawnScript.getlestourelles ();
		foreach (GameObject tr in tours) {
			Debug.Log("POWA");
			tr.GetComponent<NewBehaviourScript>().setDegat(2);
			tr.GetComponent<NewBehaviourScript>().setactivehades();
		}
		
	}
}