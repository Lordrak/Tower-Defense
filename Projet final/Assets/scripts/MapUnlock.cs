using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapUnlock : MonoBehaviour {

	int nbStage = 3;
	public int nbStageUnlock;
	[SerializeField]
	GameObject[] buttons;

	string God;
	public string GodMapUnlock;

	// Use this for initialization
	void Start () {
		foreach (GameObject button in buttons) {
			button.SetActive (false);
		}
		int i;
		int unlock = 0;

		if (GodMapUnlock == "Geb") {
			unlock = PlayerPrefs.GetInt("lvlgeb");
		}
		if (GodMapUnlock == "Zeus") {
			unlock = PlayerPrefs.GetInt("lvlzeus");
		}
		if (GodMapUnlock == "Hades") {
			unlock = PlayerPrefs.GetInt("lvlhades");
		}
		if (unlock <= 0) {
			unlock = 1;
		}
		for (i = 0; i < unlock; i++) {
			buttons [i].SetActive (true);
		}
	}

	void OnEnable(){
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

	}

	public void setMap(string mapChoose){
		PlayerPrefs.SetString ("God",mapChoose);
	}
	
}
