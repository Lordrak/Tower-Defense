using UnityEngine;
using System.Collections;

public class DifficultScript : MonoBehaviour {
	public string difficult;
	public string map;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	public void changeDifficult(string dif){
		difficult = dif;
	}

	public void changeMap(string stage){
		map = stage;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
