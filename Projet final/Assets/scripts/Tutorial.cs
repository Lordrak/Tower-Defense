using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	string orUnite;
	string instruction;
	string instructions;
	string tourelleMelee;
	string detailTourelleMelee;
	string detailTourelleArcher;
	string detailTourelleMage;
	string tourelleArcher;
	string tourelleMage;
	string améliorationTourelle;
	string description;
	string pouvoirpassif;
	string pouvoiractif;
	string pouvoirdeboost;
	string pouvoirmulti;
	string mana;
	string instructionPouvoir;

	bool passer = true;
	bool dejaSpawn;
	RaycastHit hit;
	Ray ray;
	ArrayList tourelles;
	int test = 0;
	int or = 300;
	GameObject goAmelio;
	bool amelio = false;
	
	bool clickin;



	[SerializeField]
	Transform guerrier;

	[SerializeField]
	Transform mage;
	
	[SerializeField]
	Transform archer;
	

	Transform testobject;
	[SerializeField]
	Transform plan;
	// Use this for initialization
	void Start () {
		tourelles = new ArrayList ();
		instructions = "Voici le tutoriel sur les différentes unités";
		instruction = instructions;
		orUnite = "Pour pouvoir poser une unité il faut avoir de l'or que l'on obtient en éliminant des monstres";
		detailTourelleMelee = "Voici une Unité de mélée, elle n'a pas beaucoup de porté, une vitesse d'attaque et une puissance moyennes";
		tourelleMelee = "Appuyez sur A pour poser une Unité de mélée a la position de votre curseur";
		detailTourelleArcher = "Voici une Unité archère, elle a beaucoup de porté, une bonne vitesse d'attaque et peu de puissance";
		tourelleArcher = "Appuyez sur Z pour poser une Unité archère a la position de votre curseur";
		detailTourelleMage = "Voici une Unité mage,elle a une porté moyen,une mauvaise vitesse d'attque et beaucoup de puissance";
		tourelleMage = "Appuyez sur E pour poser une Unité mage a la position de votre curseur";
		améliorationTourelle = "Si vous cliquez sur une tourelle vous pouvez améliorer la vitesse ou la puissance d'attaque de la tourelle";
		instructionPouvoir = "Bienvenue dans le tutoriel sur les pouvoirs";
		mana = "Tuer des monstres rapporte du mana qui permet après en voir gagné un certain nombrede lancer des pouvoirs divins";
		description = "Quelque soit le dieu que vous utilisez, vous avez 4 pouvoir à votre disposition";
		pouvoirpassif = "Le pouvoir passif booste vous apporte un bonus de stats permanent pour toute la partie, celui de Geb ici augmente la vie maximale de l'idole";
		pouvoiractif = "Le pouvoir actif est un sort touchant tous les ennemies présent sur la carte et leurs infligeant d'importants dégats";
		pouvoirdeboost = "Le pouvoir de boost renforce les unités que vous avez posés sur le terrain jusqu'a la fin de la vague et leurs ajoute un effet sur l'attaque";
		pouvoirmulti = "Uniquement en partie multijoueur, ce pouvoir permet d'envoyer un Boss à l'autre joueur";
	}
	void OnGUI(){
		GUI.Label (new Rect(300,150,100,200), instruction);

			if(instruction == instructions){
				if(GUI.Button(new Rect(500,150,100,25),"Passer")){
					instruction = orUnite;
				}
			}
			else if(instruction == orUnite){
				if(GUI.Button(new Rect(500,150,100,25),"Passer")){
					instruction = tourelleMelee;
				}
			}
			else if (instruction == detailTourelleMelee ) 
			{
				if(GUI.Button(new Rect(500,150,100,25),"Passer")){
					instruction = tourelleArcher;
				}
			}
			else if (instruction == detailTourelleArcher) 
			{
				if(GUI.Button(new Rect(500,150,100,25),"Passer")){
					instruction = tourelleMage;
				}
			}
			else if (instruction == detailTourelleMage) 
			{
				if(GUI.Button(new Rect(500,150,100,25),"Passer")){
					instruction = améliorationTourelle;
				}
			}

		
		if (Input.GetKeyUp ("a") && instruction == tourelleMelee) {

				
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
				}

			if (Input.GetKeyUp ("a")) {
				test++;
			}
			if(clickin){
				instruction = detailTourelleMelee;
			}
		}
		if (Input.GetKeyUp ("z") && instruction == tourelleArcher) {
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
			}
			
			if (Input.GetKeyUp ("z")) {
				test++;
			}
			if(clickin){
				instruction = detailTourelleArcher;
			}
		}
		if (Input.GetKeyUp ("e") && instruction == tourelleMage) {
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
			}
			
			if (Input.GetKeyUp ("e")) {
				test++;
			}
			if(clickin){
				instruction = detailTourelleMage;
			}
		}
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit) && instruction == améliorationTourelle) {
			if (Input.GetMouseButton (0) && (hit.collider.gameObject.name == "UniteSolo(Clone)" || hit.collider.gameObject.name == "UniteArcher(Clone)" || hit.collider.gameObject.name == "UniteMage(Clone)")) {
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
					instruction = instructionPouvoir;
				} else if (GUI.Button (new Rect (150, 10, 100, 25), "UP Speed")) {
					or -= goAmelio.GetComponent<Unité> ().getOr ();
					goAmelio.GetComponent<Unité> ().setVitesseAtt (1.2f);;
					amelio = false;
					instruction = instructionPouvoir;

				}

			} else {
				GUI.Label (new Rect (150, 10, 100, 25), "Or insuffisant");
			}
		}

		if (instruction == instructionPouvoir) {
			if (GUI.Button (new Rect (500, 150, 100, 25), "Passer")) {
				instruction = mana;
			}
		}
		if (instruction == mana) {
			if (GUI.Button (new Rect (500, 150, 100, 25), "Passer")) {
				instruction = description;
			}
		}
		if (instruction == description) {
			if (GUI.Button (new Rect (500, 150, 100, 25), "Passer")) {
				instruction = pouvoirpassif;
			}
		}
		if (instruction == pouvoirpassif) {
			if (GUI.Button (new Rect (500, 150, 100, 25), "Passer")) {
				instruction = pouvoiractif;
			}
		}
		if (instruction == pouvoiractif) {
			if (GUI.Button (new Rect (500, 150, 100, 25), "Passer")) {
				instruction = pouvoirdeboost;
			}
		}
		if (instruction == pouvoirdeboost) {
			if (GUI.Button (new Rect (500, 150, 100, 25), "Passer")) {
				instruction = pouvoirmulti;
			}
		}
		if (instruction == pouvoirmulti) {
			if (GUI.Button (new Rect (500, 150, 100, 25), "Passer")) {
				instruction = "Tutoriel Terminé";
			}
		}
		if(instruction == "Tutoriel Terminé"){
			if (GUI.Button (new Rect (150, 10, 100, 25), "Fin")){
				Application.LoadLevel("MenuBegin");
			}
		}
	}

	IEnumerator createcube(Transform testobject)
	{
		clickin = false;
		ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray,out hit))
		{
			if(hit.collider.gameObject.name =="Map" && or - testobject.GetComponent<Unité>().getOr() >= 0){
				Vector3 vec = new Vector3(hit.point.x, plan.position.y, hit.point.z + testobject.localScale.z / 2);
				
				Transform tourelle = Instantiate (testobject, vec, Quaternion.identity) as Transform;
				GameObject t = tourelle.gameObject;
				or-= 50;
				clickin = true;
			}
		}
		yield return new WaitForSeconds (2f);
	}
}
