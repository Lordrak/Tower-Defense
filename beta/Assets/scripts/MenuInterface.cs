using UnityEngine;
using System.Collections;

public class MenuInterface : MonoBehaviour {
	
	public void changeScene(string scene){
		// this object was clicked - do something

		Application.LoadLevel (scene);
	}

}
