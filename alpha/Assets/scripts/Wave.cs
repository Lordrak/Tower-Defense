using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
	[SerializeField]
	GameObject _tank;
	
	[SerializeField]
	GameObject _melee;
	
	[SerializeField]
	GameObject _distant;
	int _baseWaveValue;
	int _waveNumber;
	int _waveValue;
	// Use this for initialization
	void Start () {


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
		_baseWaveValue = 20;
		randSpawn ();
		StartCoroutine (randSpawn());
	}

	IEnumerator randSpawn (){
		ArrayList _mob = new ArrayList ();
		int i = 0;
		while (i < _baseWaveValue) {
			GameObject mob = _tank;
			_mob.Add (mob);
			i=i+1;
		}
		foreach (GameObject truc in _mob) {
			truc.SetActive(true);
			yield return new WaitForSeconds (1f);
		}
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
	// Update is called once per frame
	void Update () {
	
	}
}
