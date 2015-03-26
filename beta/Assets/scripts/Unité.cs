using UnityEngine;
using System.Collections;

public class Unité : MonoBehaviour {

	[SerializeField]
	public int _degat;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public int getDegat(){
		return _degat;
	}


}
