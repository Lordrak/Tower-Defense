using UnityEngine;
using System.Collections;


public class NewBehaviourScript : MonoBehaviour {
	[SerializeField]
	Transform _cube;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Adversaire") {
			other.gameObject.GetComponent<Adversaire> ().setVie (1); 
			if (other.gameObject.GetComponent<Adversaire> ().getVie () <= 0) {
				Destroy (other.gameObject);
			}

		} 
	}
}