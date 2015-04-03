using UnityEngine;
using System.Collections;

public class input : MonoBehaviour {


	[SerializeField]
	 RectTransform buttoncu;

	[SerializeField]
	RectTransform buttonca;

	[SerializeField]
	RectTransform buttoncy;

	[SerializeField]
	RectTransform buttonsp;

	RectTransform butcu;
	RectTransform butca;
	RectTransform butcy;
	RectTransform butsp;
	// Use this for initialization
	void Start () {
		butcu = Instantiate (buttoncu) as RectTransform ;
		butca = Instantiate (buttonca) as RectTransform ;
		butcy = Instantiate (buttoncy) as RectTransform ;
		butsp = Instantiate (buttonsp) as RectTransform ;
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetKeyDown("a")) {
		butcu.SendMessage("createcube",SendMessageOptions.RequireReceiver);
	}
	/*if (Input.GetKeyDown("z")) {
		butca.SendMessage("createcube",SendMessageOptions.RequireReceiver);
	}
	if (Input.GetKeyDown("e")) {
		butcy.SendMessage("createcube",SendMessageOptions.RequireReceiver);
	}
	if (Input.GetKeyDown("r")) {
		butsp.SendMessage("createcube",SendMessageOptions.RequireReceiver);
	}*/
}
}