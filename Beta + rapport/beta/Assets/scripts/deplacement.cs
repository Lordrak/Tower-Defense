using UnityEngine;
using System.Collections;

public class deplacement : MonoBehaviour {

	

	public int nb;

	[SerializeField]
	NavMeshAgent _agent;

	[SerializeField]
	Transform _destination;

	// Use this for initialization
	void OnEnable () {
		_agent.SetDestination (_destination.position);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
