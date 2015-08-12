using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallsterPathing : MonoBehaviour {

	public List<Transform> path;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		GameObject pathobj = GameObject.Find ("Path");
		path = new List<Transform> ();
		for (int i = 0; i<pathobj.transform.childCount; i++) {
			path.Add(pathobj.transform.GetChild(i));
		}
		path.Add (GameObject.Find ("Core").transform);
		agent = GetComponent<NavMeshAgent> ();
		NextDestination ();
	}
	
	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance <= 0.5f) {
			if(path.Count>0)
				NextDestination();
			else{
				GameObject.Find("Core").BroadcastMessage("Damage");
				Destroy(gameObject);
			}
		}
	}

	private void NextDestination(){
		agent.SetDestination (path[0].position);
		path.RemoveAt (0);
	}
}
