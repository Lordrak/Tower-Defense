using UnityEngine;
using System.Collections;

public class InterfaceInGame : MonoBehaviour {

	[SerializeField]
	GameObject _idole;

	[SerializeField]
	GameObject text;

	int or;

	void OnGUI()
	{
		GUI.Label(new Rect(300,100,100,25),"point de vie : "+_idole.GetComponent<scriptIdole>().getVie());	
	}


}
