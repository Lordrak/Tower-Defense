using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapUnlock : MonoBehaviour {

	int nbStage = 3;
	public int nbStageUnlock;

	[SerializeField]
	GameObject[] buttons;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (this);
		foreach (GameObject button in buttons) {
			button.SetActive (false);
		}
		int i;
		for (i = 0; i < nbStageUnlock; i++) {
			buttons [i].SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

	}

	public void map(){
		DontDestroyOnLoad (this);
	}

	public void upNbStageUnlock(int SU){
		nbStageUnlock = SU;
	}
}
