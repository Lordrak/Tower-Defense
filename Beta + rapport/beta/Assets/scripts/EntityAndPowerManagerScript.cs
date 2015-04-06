using UnityEngine;
using System.Collections;

public class EntityAndPowerManagerScript : MonoBehaviour {

	[SerializeField]
	Adversaire[] _enemies;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(DoSpell());
		}
	}

	IEnumerator DoSpell()
	{
		Debug.Log("Affiche Image");
		yield return new WaitForSeconds(5f);

		foreach (var ad in _enemies)
			if (ad.gameObject.activeInHierarchy)
				ad._vie -= 1;
	}
}
