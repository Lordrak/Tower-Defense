using UnityEngine;
using System.Collections;

public class Tutorialpowers : MonoBehaviour {

	string instruction;
	string instructions;
	string description;
	string pouvoirpassif;
	string pouvoiractif;
	string pouvoirdeboost;
	string pouvoirmulti;
	string mana;

	// Use this for initialization
	void Start () {
		instructions = "Bienvenue dans le tutoriel sur les pouvoirs";
		instruction = instructions;
		mana = "Tuer des monstres rapporte du mana qui permet après en voir gagné un certain nombrede lancer des pouvoirs divins";
		description = "Quelque soit le dieu que vous utilisez, vous avez 4 pouvoir à votre disposition";
		pouvoirpassif = "Le pouvoir passif booste vous apporte un bonus de stats permanent pour toute la partie, celui de Geb ici augmente la vie maximale de l'idole";
		pouvoiractif = "Le pouvoir actif est un sort touchant tous les ennemies présent sur la carte et leurs infligeant d'importants dégats";
		pouvoirdeboost = "Le pouvoir de boost renforce les unités que vous avez posés sur le terrain jusqu'a la fin de la vague et leurs ajoute un effet sur l'attaque";
		pouvoirmulti = "Uniquement en partie multijoueur, ce pouvoir permet d'envoyer un Boss à l'autre joueur";
	}

	void OnGUI()
	{
		GUI.Label (new Rect (500, 150, 100, 25), instruction);
		if (instruction == instructions) {
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
				GUI.Button(new Rect())
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
	}

}
