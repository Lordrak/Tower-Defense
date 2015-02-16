using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NewBehaviourScript : MonoBehaviour {

	[SerializeField]
	GameObject _map;

	string nom;

	int degat = 1;

	List<GameObject> _objectsInside;
	float timeLeft = 0.5f;

	// Use this for initialization
	void Start ()
	{

		_objectsInside = new List<GameObject> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {

			StartCoroutine(ShootCoroutine ());
			timeLeft = 0.5f;
		}
	}


	IEnumerator ShootCoroutine(){
		while (_objectsInside.Count> 0) {
			_objectsInside[0].GetComponent<Adversaire> ().setVie (degat);
			yield return new WaitForSeconds(100f);
		}

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
				_map.GetComponent<WaveSpawnScript>().recupereMort(other.GetComponent<Adversaire>().getNom());
				_objectsInside.Remove (other.gameObject);
				Destroy(other.gameObject);
			}
		}


	}
	void setNom(int nb){
		nom = nom + nb;
	}

	public void setDegat(int deg){
		Debug.Log(""+degat);
		degat += deg;

	}

	public void setVitesseAtt(float vit){
		Debug.Log(""+timeLeft);
		timeLeft /= vit; 
	}

}




