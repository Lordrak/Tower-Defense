using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unité : MonoBehaviour {

	[SerializeField]
	GameObject _map;
	
	string nom;
	[SerializeField]
	int or;
	int nbAmelio;
	
	int degat = 1;
	
	List<GameObject> _objectsInside;
	float timeLeft = 0.5f;

	bool activehades = false;
	bool activegeb = false;
	bool activezeus = false;
	
	// Use this for initialization
	void Start ()
	{
		// 		nbAmelio;
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
				_map.GetComponent<Wave>().recupereMort(other.GetComponent<Adversaire>().getNom(),other.gameObject);
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
	
	IEnumerator Dotboosthades(float timedot, GameObject mob) 
	{
		int i = 0;
		Debug.Log (timedot);
		while (i < timedot) {
			mob.GetComponent<Adversaire>().setVie(1);
			Debug.Log("Vie du monstre :"+ _objectsInside[0].GetComponent<Adversaire> ().getVie());
			i++;
			yield return new WaitForSeconds(1f);
		}
		
	}
	public void setactivehades()
	{
		activehades = true;
	}

	


}
