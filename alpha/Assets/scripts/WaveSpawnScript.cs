using UnityEngine;
using System.Collections;
public class WaveSpawnScript : MonoBehaviour {

	public string IP = "127.0.0.1";
	public int Port = 25001;

	[SerializeField]
	GameObject _tank;

	[SerializeField]
	Transform testobject;

	[SerializeField]
	Transform plan;

	[SerializeField]
	GameObject _melee;

	[SerializeField]
	GameObject _distant;

	int nbTourellePosable;
	bool clientPret;
	Ray ray;
	RaycastHit hit;
	int test = 0;
	ArrayList listMort;
	ArrayList tourelles;
	ArrayList lesTourelles;
	int _waveNumber;
	int nbMob;
	bool DejaMort ;
	bool dejaSpawn;
	int _waveValue;
	int lancer ;
	int _baseWaveValue;
	int _nbMelee = 0;
	int _nbTank = 0;
	int _nbDistant = 0;
	// Use this for initialization
	void Start () {
		clientPret = false;
		nbTourellePosable = 5;
		lancer = 0;
		tourelles = new ArrayList ();
		lesTourelles = new ArrayList ();
		listMort = new ArrayList ();
		foreach(Transform meleeChild in _melee.transform){
				meleeChild.gameObject.SetActive(false);
		}
		foreach(Transform tankChild in _tank.transform){
				tankChild.gameObject.SetActive(false);
		}
		foreach(Transform distantChild in _distant.transform){
				distantChild.gameObject.SetActive(false);
		}
		_waveNumber = 1;
		_baseWaveValue = 10;


	}

	IEnumerator randSpawn (){
		clientPret = false;
		lancer = 1;
		nbTourellePosable = 3;
		ArrayList _Spawnable = new ArrayList();
		ArrayList _Spawned = new ArrayList ();
		while (lancer == 1) {
			_waveValue = _baseWaveValue;
			while (_waveValue > 0) {
				if (_waveValue > TankStats.waveValue) {
					_Spawnable.Add (_tank);
				}
				if (_waveValue > MeleeStats.waveValue) {
					_Spawnable.Add (_melee);
				}
				if (_waveValue > DistantStats.waveValue) {
					_Spawnable.Add (_distant);
				}
				int rnd = Random.Range (0, 3);
				_Spawned.Add (_Spawnable [rnd]);
				if (_Spawnable [rnd] == _tank) {
					_waveValue -= TankStats.waveValue;
								}
				if (_Spawnable [rnd] == _melee) {
					_waveValue -= MeleeStats.waveValue;
				}
				if (_Spawnable [rnd] == _distant) {
					_waveValue -= DistantStats.waveValue;
				}
			}
			for (int i = 0; i<_Spawned.Count; i++) {
				if (_Spawned [i] == _melee) {
					_nbMelee++;
				}
				else if (_Spawned [i] == _tank) {
					_nbTank++;
				} 
				else
				{
					_nbDistant++;
				}
			}
			Debug.Log(_nbMelee+"  "+_nbTank+"  "+_nbDistant);
			nbMob = _nbMelee + _nbTank + _nbDistant;
			while (_nbMelee > 0 || _nbTank > 0 || _nbDistant > 0) {
				foreach (Transform meleeChild in _melee.transform) {
					if (_nbMelee > 0) {
						meleeChild.gameObject.GetComponent<Adversaire>().setNom("_melee"+_nbMelee);
						meleeChild.gameObject.SetActive (true);
						_nbMelee--;
						yield return new WaitForSeconds (2f);
					}
				}
				foreach (Transform tankChild in _tank.transform) {
					if (_nbTank > 0) {
						tankChild.gameObject.GetComponent<Adversaire>().setNom("_tank"+_nbTank);
						tankChild.gameObject.SetActive (true);
						_nbTank--;
						yield return new WaitForSeconds (2f);
					}
				}
				foreach (Transform distantChild in _distant.transform) {
					if (_nbDistant > 0) {
						distantChild.gameObject.GetComponent<Adversaire>().setNom("_distant"+_nbDistant);
						distantChild.gameObject.SetActive (true);
						_nbDistant--;
						yield return new WaitForSeconds (2f);
					}
		 		}
			}
			lancer = 2;

			_waveNumber++;
			_baseWaveValue += 2 * _waveNumber;


			
		}
	}
	//------------------------------------------------------------------------------------
	public void recupereMort(string mort){
		DejaMort = false;
		foreach (string unMort in listMort) {
			if(mort == unMort){
				DejaMort = true;
			}
		}
		if (!DejaMort) {
			listMort.Add(mort);

		}
		Debug.Log (listMort.Count+"  "+nbMob);
		if (listMort.Count == nbMob) {
			lancer = 0;
		}
	}
	//------------------------------------------------------------------------------
	void OnGUI(){
		if (Network.peerType == NetworkPeerType.Disconnected) {
			Application.LoadLevel ("MenuNetworking");
		} 
		else {
			if (lancer == 0) {
				
				GUI.Label(new Rect(200,50,100,25),"A : unité de base");
				GUI.Label(new Rect(150,100,100,25),nbTourellePosable +" unités à poser");
				if (Input.GetKeyDown("a") && nbTourellePosable > 0) {
					
					dejaSpawn = false;
					foreach(int tourelle in tourelles){
						if(tourelle == test){
							dejaSpawn = true;
							
						}
					}
					if(!dejaSpawn){
						tourelles.Add(test);
						StartCoroutine(createcube());
						nbTourellePosable --;
					}
					
					
				}
				if(Input.GetKeyUp("a")){
					test++;
				}


			}
			if (Network.peerType == NetworkPeerType.Client) {
				if(!clientPret && lancer == 0){
				if (GUI.Button (new Rect (50, 50, 100, 25), "Pret")) {
					networkView.RPC ("clientPretRPC", RPCMode.All);
				}
			}
			}
			else{
				if(clientPret && lancer == 0){
					if (GUI.Button (new Rect (50, 50, 100, 25), "Pret")) {
						listMort = new ArrayList ();
						networkView.RPC ("lancerGame", RPCMode.All);
						}
				}
				GUI.Label (new Rect (100, 100, 100, 25), "Server");
				}
			if (GUI.Button (new Rect (100, 125, 100, 25), "Logout")) {
				Network.Disconnect (250);
			}
		}


	}

	//---------------------------------------------------------------
	[RPC]
	void clientPretRPC(){
		Pret ();
	}

	[RPC]
	void lancerGame(){
		StartCoroutine (randSpawn());
	}

	void Pret(){
		clientPret = true;
	}
	public class TankStats{
		public int HP =  20;
		public int damage = 2;
		public int resist = 2;
		public static int waveValue =5;
	}
	public class MeleeStats{
		public int HP =  15;
		public int damage = 1;
		public int resist = 1;
		public static int waveValue =1;
	}
	public class DistantStats{
		public int HP =  10;
		public int damage = 3;
		public int resist = 1;
		public static int waveValue =2;
	}
	
	IEnumerator createcube()
	{
		ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray,out hit))
		{
			if(hit.collider.gameObject.name =="Map"){
				Vector3 vec = new Vector3(hit.point.x + 2, plan.position.y + testobject.localScale.y / 2, hit.point.z);

				Transform tourelle = Instantiate (testobject, vec, Quaternion.identity) as Transform;
				GameObject t = tourelle.gameObject;
				lesTourelles.Add(t);

			}
			else{
				nbTourellePosable ++;
			}
		}
		yield return new WaitForSeconds (2f);
	}
	// Update is called once per frame
	void Update () {
	}
}
