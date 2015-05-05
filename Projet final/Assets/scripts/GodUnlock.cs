using UnityEngine;
using System.Collections;

public class GodUnlock : MonoBehaviour {

	[SerializeField]
	public GameObject gebUnlock;
	
	[SerializeField]
	public GameObject zeusUnlock;
	
	[SerializeField]
	public GameObject hadesUnlock;
	// Use this for initialization
	void Start () {
		zeusUnlock.SetActive (false);
		if (PlayerPrefs.GetString ("Zeus") == "Unlock") {
			zeusUnlock.SetActive (true);
		}
		hadesUnlock.SetActive (false);
		if (PlayerPrefs.GetString ("Hades") == "Unlock") {
			hadesUnlock.SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
