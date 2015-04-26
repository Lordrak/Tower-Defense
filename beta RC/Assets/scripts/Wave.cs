using UnityEngine;
using System.Collections;
public class Wave : MonoBehaviour {

	
	[SerializeField]
	GameObject Idole;

	[SerializeField]
	GameObject _tank;
	
	[SerializeField]
	Camera camAmelio;
	
	[SerializeField]
	Transform testobject;

	GameObject stage;

	[SerializeField]
	Transform guerrier;
	
	[SerializeField]
	Transform mage;
	
	[SerializeField]
	Transform archer;

	[SerializeField]
	Transform golem;
	
	[SerializeField]
	Transform griffon;

	[SerializeField]
	Transform thanatos;
	
	[SerializeField]
	Transform plan;

	int unlock = 1;

	[SerializeField]
	GameObject _boss;
	
	[SerializeField]
	GameObject _melee;
	
	[SerializeField]
	GameObject _distant;

	[SerializeField]
	GameObject _stageDifficult;

	public bool spawnBoss;
	public int numberWaveMax;
	bool amelio = false;
	int nbTourellePosable;
	bool clientPret;
	Ray ray;
	GameObject goAmelio;
	RaycastHit hit;
	int test = 0;
	ArrayList listMort;
	ArrayList tourelles;
	public static ArrayList lesTourelles;
	int _waveNumber;
	int nbMob;
	int or;
	int mana;
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
		Debug.Log(PlayerPrefs.GetString("God"));
		or = 300;
		mana = 0;
		clientPret = false;
		nbTourellePosable = 3;
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
		foreach(Transform bossChild in _boss.transform){
			bossChild.gameObject.SetActive (false);
		}

		_waveNumber = 1;
		Debug.Log (numberWaveMax+"-"+_waveNumber);
		if(PlayerPrefs.GetString("difficult") == "easy"){
			_baseWaveValue = 8;
		}
		else if(PlayerPrefs.GetString("difficult") == "middle"){
			_baseWaveValue = 10;
		}
		else if(PlayerPrefs.GetString("difficult") == "hard"){
			_baseWaveValue = 15;
		}

		
		
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
			if (_waveNumber == numberWaveMax && spawnBoss == true) 
			{
				foreach(Transform bossChild in _boss.transform){
					nbMob ++;
					bossChild.gameObject.GetComponent<Adversaire>().setNom(bossChild.name);
					bossChild.gameObject.SetActive (true);
				}
				spawnBoss = false;
			}
		}

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
				or += 50;
				mana += 5;
				if (PlayerPrefs.GetString("GodChoosen") == "Hades") 
				{
					mana += 3;
				}
				if (mana >= 100)
				{
					mana = 100;
				}


			}
			listMort.Add(mort);
			
		}
		if (listMort.Count == nbMob) {
			if(_waveNumber == numberWaveMax){
				if(PlayerPrefs.GetString("difficult") == "easy"){
					unlock = 2;
				}
				else if(PlayerPrefs.GetString("difficult") == "middle"){
					unlock = 3;
				}
				else if(PlayerPrefs.GetString("difficult") == "hard"){
					unlock = 3;
					PlayerPrefs.SetString (PlayerPrefs.GetString("God"),"Unlock");
				}
				if(PlayerPrefs.GetString("God") == "Zeus"){
					PlayerPrefs.SetInt("lvlzeus",unlock);
				}
				if(PlayerPrefs.GetString("God") == "Geb"){
					PlayerPrefs.SetInt("lvlgeb",unlock);
				}
				if(PlayerPrefs.GetString("God") == "Hades"){
					PlayerPrefs.SetInt("lvlhades",unlock);
				}
				if(PlayerPrefs.GetString("difficult") == "hard"){
					Application.LoadLevel("GodUnlock");
				}
				else{
					Application.LoadLevel("MenuBegin");
				}
			}
			_waveNumber++;
			_baseWaveValue += 2 * _waveNumber;
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

		if (listMort.Count == nbMob) {
			lancer = 0;
		}
	}
	//------------------------------------------------------------------------------
	void OnGUI(){
				GUI.Label (new Rect (300, 150, 100, 25), "Or : " + or);
				GUI.Label (new Rect (300, 180, 100, 25), "Mana : " + mana);
				if (lancer == 0) {
						GUI.Label (new Rect (200, 50, 100, 25), "A : unité de base");
						GUI.Label (new Rect (150, 100, 100, 25), nbTourellePosable + " unités à poser");
						if (Input.GetKeyDown ("a") && nbTourellePosable > 0) {
								
								dejaSpawn = false;
								foreach (int tourelle in tourelles) {
											
										if (tourelle == test) {
												dejaSpawn = true;
												
										}
								}
								Debug.Log (dejaSpawn);
								if (!dejaSpawn) {
						
										tourelles.Add (test);
										StartCoroutine (createcube (guerrier));
										nbTourellePosable --;
								}
						}
						if (Input.GetKeyUp ("a")) {
								test++;
						}
					if (Input.GetKeyDown ("z") && nbTourellePosable > 0) {
						
						dejaSpawn = false;
						foreach (int tourelle in tourelles) {
							
							if (tourelle == test) {
								dejaSpawn = true;
								
							}
						}
						Debug.Log (dejaSpawn);
						if (!dejaSpawn) {
							
							tourelles.Add (test);
							StartCoroutine (createcube (archer));
							nbTourellePosable --;
						}
					}
					if (Input.GetKeyUp ("z")) {
						test++;
					}
					if (Input.GetKeyDown ("e") && nbTourellePosable > 0) {
						
						dejaSpawn = false;
						foreach (int tourelle in tourelles) {
							
							if (tourelle == test) {
								dejaSpawn = true;
								
							}
						}
						Debug.Log (dejaSpawn);
						if (!dejaSpawn) {
							
							tourelles.Add (test);
							StartCoroutine (createcube (mage));
							nbTourellePosable --;
						}
					}
					if (Input.GetKeyUp ("e")) {
						test++;
					}
					if (Input.GetKeyDown ("r") && nbTourellePosable > 0) {
						
						dejaSpawn = false;
						foreach (int tourelle in tourelles) {
							
							if (tourelle == test) {
								dejaSpawn = true;
								
							}
						}
						Debug.Log (dejaSpawn);
						if (!dejaSpawn) {
							
							tourelles.Add (test);
					if(PlayerPrefs.GetString("GodChoosen") == "Geb"){
						StartCoroutine (createcube (golem));					}
					else if(PlayerPrefs.GetString("GodChoosen") == "Zeus"){
						StartCoroutine (createcube (griffon));					}
					else if(PlayerPrefs.GetString("GodChoosen") == "Hades"){
						StartCoroutine (createcube(thanatos));}
							nbTourellePosable --;
						}
					}
					if (Input.GetKeyUp ("r")) {
						test++;
					}
						ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						if (Physics.Raycast (ray, out hit)) {
								if (Input.GetMouseButton (0) && hit.collider.gameObject.name == "Unite(Clone)") {
										amelio = true;
										goAmelio = hit.collider.gameObject;
								}
						}
						if (amelio) {
				Debug.Log(or+" - "+goAmelio.GetComponent<Unité> ().getOr ());
				if (or - goAmelio.GetComponent<Unité> ().getOr () >= 0) {
										if (GUI.Button (new Rect (50, 10, 100, 25), "UP Att")) {
						or -= goAmelio.GetComponent<Unité> ().getOr ();
						goAmelio.GetComponent<Unité> ().setDegat (3);
												amelio = false;
										} else if (GUI.Button (new Rect (150, 10, 100, 25), "UP Speed")) {
						or -= goAmelio.GetComponent<Unité> ().getOr ();
						goAmelio.GetComponent<Unité> ().setVitesseAtt (1.2f);
												amelio = false;
										}
								} else {
										GUI.Label (new Rect (150, 10, 100, 25), "Or insuffisant");
								}
						}
			if (GUI.Button (new Rect (50, 50, 100, 25), "Pret")) {
				listMort = new ArrayList ();
				StartCoroutine (randSpawn());
				
			}
		}
		
		}
		
		
	
	//---------------------------------------------------------------
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
	
	IEnumerator createcube(Transform testobject)
	{
		ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray,out hit))
		{
			if(hit.collider.gameObject.name =="Map" && or - testobject.GetComponent<Unité>().getOr() >= 0){
				Vector3 vec = new Vector3(hit.point.x, plan.position.y, hit.point.z + testobject.localScale.z / 2);
				
				Transform tourelle = Instantiate (testobject, vec, Quaternion.identity) as Transform;
				GameObject t = tourelle.gameObject;
				lesTourelles.Add(t);
				or-= t.GetComponent<Unité>().getOr();
				
			}
			else{
				nbTourellePosable ++;
			}
		}
		else{
			nbTourellePosable ++;
		}
		yield return new WaitForSeconds (2f);
	}
	// Update is called once per frame

	public static ArrayList getlestourelles()
	{
		return lesTourelles;
	}
	public int getMana(){
		return mana;
	}


}
