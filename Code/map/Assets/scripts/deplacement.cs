using UnityEngine;
using System.Collections;

public class deplacement : MonoBehaviour {

	[SerializeField]
	NavMeshAgent _agent;

	[SerializeField]
	Transform _destination;

	// Use this for initialization
	void Start () {
		_agent.SetDestination(_destination.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
