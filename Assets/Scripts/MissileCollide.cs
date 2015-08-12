using UnityEngine;
using System.Collections;

public class MissileCollide : MonoBehaviour {
	public float damage;
	private GameObject target;
	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Target") {
			Destroy (this.gameObject);
			c.gameObject.BroadcastMessage("Damage", damage);
		}
	}

	void Update(){
		target = GameObject.FindWithTag ("Target");
		if(target!=null)
			GetComponent<NavMeshAgent> ().SetDestination (target.transform.position);
	}
}
