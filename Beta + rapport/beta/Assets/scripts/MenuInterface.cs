using UnityEngine;
using System.Collections;

public class MenuInterface : MonoBehaviour {
	public string mapChoose;
	public bool clear;

	public void changeScene(){
		// this object was clicked - do something

		Application.LoadLevel (mapChoose);
	}

	public void map(string map){
		mapChoose = map;
	}

	public void Succes(bool finish){
		clear = finish;
	}
	public void sceneMulti(){
		// this object was clicked - do something
		
		Application.LoadLevel ("MenuNetworking");
	}
}
