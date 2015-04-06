using UnityEngine;
using System.Collections;

public class GodChooseScript : MonoBehaviour {

	public string god;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);

	}
	public void changeGod(string godChoose){
		god = godChoose;	
	}
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.Label (new Rect (400,50,100,25), god);
	}

	public string getGod(){
		return god;
	}
}
