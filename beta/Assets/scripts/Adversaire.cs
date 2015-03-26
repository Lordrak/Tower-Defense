using UnityEngine;
using System.Collections;

public class Adversaire : MonoBehaviour {
	[SerializeField]
	public int _vie;

	[SerializeField]
	public int _degat;

	public string _nom;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setVie(int degat){
		_vie = _vie - degat;
	}
	public int getVie(){
		return _vie;
	}

	public int getDegat(){
		return _degat;
	}

	public void setNom(string nom){
		_nom = nom;
	}

	public string getNom(){
		return _nom;
	}
}
