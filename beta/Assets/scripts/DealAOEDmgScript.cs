using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DealAOEDmgScript : MonoBehaviour {
	[SerializeField]
	GameObject _map;
	[SerializeField]
	int or;
	int nbAmelio;

	List<GameObject> _objectsInside;
	float timeLeft = 0.5f;

	void Start ()
	{
		_objectsInside = new List<GameObject> ();
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Adversaire") {
			_objectsInside.Add (other.gameObject);
		}
		
		
	}


	void OnTriggerExit(Collider other){
		_objectsInside.Remove (other.gameObject);
	}
	
	void OnTriggerStay(Collider other){
				if (other.gameObject.tag == "Adversaire") {
					if (other.gameObject.GetComponent<Adversaire> ().getVie () <= 0) {
						_map.GetComponent<Wave> ().recupereMort (other.GetComponent<Adversaire>().getNom(), other.gameObject);
						_objectsInside.Remove (other.gameObject);
						Destroy (other.gameObject);
				}
			}
	}
	// Update is called once per frame
	void Update () {
		if (_objectsInside.Count > 0) {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				StartCoroutine(Burn ());
				timeLeft = 0.5f;
			}
		}	
	}
	
	public void setDegat(int deg){
		int degat = this.gameObject.GetComponent<Unité> ().getDegat();
		degat += deg;
		setOr ();
		
	}
	
	public void setVitesseAtt(float vit){
		Debug.Log(""+timeLeft);
		timeLeft /= vit; 
		setOr ();
	}

	public int getOr()
	{
		return or;
	}
	
	public void setOr(){
		or += or * nbAmelio;
		nbAmelio += 1;
	}

	IEnumerator Burn(){
		int degat = this.gameObject.GetComponent<Unité> ().getDegat ();
		if (_objectsInside.Count> 0) {
			Debug.Log ("Burn");
			for (int i = _objectsInside.Count - 1; i >= 0; i--) {
				_objectsInside[i].GetComponent<Adversaire> ().setVie(degat);
			}

		}
		yield return new WaitForSeconds(1f);
	}
}
