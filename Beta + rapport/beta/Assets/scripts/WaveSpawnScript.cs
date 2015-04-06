using UnityEngine;
using System.Collections;
public class WaveSpawnScript : MonoBehaviour {
	
	public string IP = "127.0.0.1";
	public int Port = 25001;
	
	[SerializeField]
	GameObject _tank;
	
	[SerializeField]
	Camera camAmelio;
	
	[SerializeField]
	Transform guerrier;
	
	[SerializeField]
	Transform archer;
	
	[SerializeField]
	Transform mage;
	
	
	[SerializeField]
	Transform plan;
	
	[SerializeField]
	GameObject _melee;
	
	[SerializeField]
	GameObject _distant;
	
	[SerializeField]
	GameObject boss;
	
	bool amelio = false;
	int nbTourellePosable;
	bool clientPret;
	Ray ray;
	GameObject goAmelio;
	RaycastHit hit;
	int test = 0;
	ArrayList listMort;
	ArrayList tourelles;
	static ArrayList lesTourelles;
	int _waveNumber;
	int nbMob;
	int or;
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
		or = 500;
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
		boss.SetActive (false);
		
		
	}
	
	IEnumerator randSpawn (){
		clientPret = false;
		lancer = 1;
		nbTourellePosable = 3;
		nbMob = nbMobWave ();
		while (_nbMelee > 0 || _nbTank > 0 || _nbDistant > 0) {
			foreach (Transform meleeChild in _melee.transform) {
				if (_nbMelee > 0) {
					Vector3 vecMelee = new Vector3(meleeChild.position.x, meleeChild.position.y, meleeChild.position.z);
					Transform melee= Instantiate (meleeChild, vecMelee, Quaternion.identity) as Transform;
					melee.gameObject.GetComponent<Adversaire>().setNom("_melee"+_nbMelee);
					melee.gameObject.SetActive (true);
					_nbMelee--;
					yield return new WaitForSeconds (2f);
				}
			}
			foreach (Transform tankChild in _tank.transform) {
				if (_nbTank > 0) {
					Vector3 vecTank = new Vector3(tankChild.position.x, tankChild.position.y, tankChild.position.z);
					Transform tank = Instantiate (tankChild, vecTank, Quaternion.identity) as Transform;
					tank.gameObject.GetComponent<Adversaire>().setNom("_tank"+_nbTank);
					tank.gameObject.SetActive (true);
					_nbTank--;
					yield return new WaitForSeconds (2f);
				}
			}
			foreach (Transform distantChild in _distant.transform) {
				if (_nbDistant > 0) {
					Vector3 vecDistance = new Vector3(distantChild.position.x, distantChild.position.y, distantChild.position.z);
					Transform distance = Instantiate (distantChild, vecDistance, Quaternion.identity) as Transform;
					distance.gameObject.GetComponent<Adversaire>().setNom("_distant"+_nbDistant);
					distance.gameObject.SetActive (true);
					_nbDistant--;
					yield return new WaitForSeconds (2f);
				}
			}
		}
		if (_waveNumber == 2 ) 
		{
			boss.SetActive(true);
		}
		_waveNumber++;
		_baseWaveValue += 2 * _waveNumber;
	}
	//------------------------------------------------------------------------------------
	public void recupereMort(string mort, GameObject GOmort){
		DejaMort = false;
		foreach (string unMort in listMort) {
			if(mort == unMort){
				DejaMort = true;
			}
		}
		if (!DejaMort) {
			if(GOmort.tag == "Adversaire"){
				or += 5;
			}
			listMort.Add(mort);
			
		}
		if (listMort.Count == nbMob) {
			lancer = 0;
		}
	}
	
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
		GUI.Label(new Rect(300,150,100,25),"Or : "+or);
		
		if (Network.peerType == NetworkPeerType.Disconnected) {
			Application.LoadLevel ("MenuNetworking");
		} 
		else {
			if (lancer == 0 ) {
				
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
						StartCoroutine(createcube(guerrier));
						nbTourellePosable --;
					}
					
					
				}
				if(Input.GetKeyUp("a")){
					test++;
				}
				if (Input.GetKeyDown("z") && nbTourellePosable > 0) {
					
					dejaSpawn = false;
					foreach(int tourelle in tourelles){
						if(tourelle == test){
							dejaSpawn = true;
							
						}
					}
					if(!dejaSpawn){
						
						tourelles.Add(test);
						StartCoroutine(createcube(archer));
						nbTourellePosable --;
					}
					
					
				}
				if(Input.GetKeyUp("z")){
					test++;
				}
				if (Input.GetKeyDown("e") && nbTourellePosable > 0) {
					
					dejaSpawn = false;
					foreach(int tourelle in tourelles){
						if(tourelle == test){
							dejaSpawn = true;
							
						}
					}
					if(!dejaSpawn){
						
						tourelles.Add(test);
						StartCoroutine(createcube(mage));
						nbTourellePosable --;
					}
					
					
				}
				if(Input.GetKeyUp("e")){
					test++;
				}
				ray=Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray,out hit))
				{
					if(Input.GetMouseButton(0) && hit.collider.gameObject.name == "Unite(Clone)"){
						amelio = true;
						goAmelio = hit.collider.gameObject;
					}
				}
				if(amelio){
					if(or - goAmelio.GetComponent<NewBehaviourScript>().getOr() >= 0){
						if(GUI.Button (new Rect (50, 10, 100, 25), "UP Att")){
							goAmelio.GetComponent<NewBehaviourScript>().setDegat(3);
							or -= goAmelio.GetComponent<NewBehaviourScript>().getOr();
							amelio = false;
						}
						else if(GUI.Button (new Rect (150, 10, 100, 25), "UP Speed")){
							goAmelio.GetComponent<NewBehaviourScript>().setVitesseAtt(1.2f);
							or -= goAmelio.GetComponent<NewBehaviourScript>().getOr();
							amelio = false;
						}
						
					}
					else{
						GUI.Label(new Rect(150, 10, 100, 25),"Or insuffisant");
					}
					
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
	
	public int nbMobWave(){
		ArrayList _Spawnable = new ArrayList ();
		ArrayList _Spawned = new ArrayList ();
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
			} else if (_Spawned [i] == _tank) {
				_nbTank++;
			} else {
				_nbDistant++;
			}
			
		}
		nbMob = _nbMelee + _nbTank + _nbDistant;
		return nbMob;
	}
	
	IEnumerator createcube(Transform unit)
	{
		ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray,out hit))
		{
			if(hit.collider.gameObject.name =="Map" && or - unit.GetComponent<NewBehaviourScript>().getOr() >= 0){
				Vector3 vec = new Vector3(hit.point.x + 2, plan.position.y + unit.localScale.y / 2, hit.point.z);
				
				Transform tourelle = Instantiate (unit, vec, Quaternion.identity) as Transform;
				GameObject t = tourelle.gameObject;
				lesTourelles.Add(t);
				or-= t.GetComponent<NewBehaviourScript>().getOr();
				
			}
			else{
				nbTourellePosable ++;
			}
		}
		yield return new WaitForSeconds (2f);
	}
	// Update is called once per frame
	void Update () {
		Debug.Log (lancer);
	}
	public static ArrayList getlestourelles()
	{
		return lesTourelles;
	}
}
