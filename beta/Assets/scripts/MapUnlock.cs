using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapUnlock : MonoBehaviour {

	public int nbStage = 3;
	public int nbStageUnlock = 1;

	[SerializeField]
	GameObject[] buttons;

	// Use this for initialization
	void Start () {
		foreach (GameObject button in buttons) {
			button.SetActive (false);
		}
		buttons [0].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

	}
}
