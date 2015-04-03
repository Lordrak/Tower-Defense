using UnityEngine;
using System.Collections;

public class DifficultScript : MonoBehaviour {
	public string difficult;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	public void changeDifficult(string dif){
		difficult = dif;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
