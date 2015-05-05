using UnityEngine;
using System.Collections;

public class GodChooseScript : MonoBehaviour {

	public string god;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);

	}
	public void changeGod(string godChoose){
		PlayerPrefs.SetString ("GodChoosen", godChoose);	
	}
	// Update is called once per frame
	void Update () {
		
	}

	public string getGod(){
		return god;
	}
}
