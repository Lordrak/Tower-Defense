using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {



	[SerializeField]
	Transform _button;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onMouseClick()
	{
		Application.LoadLevel ("terrain");
	}
}
