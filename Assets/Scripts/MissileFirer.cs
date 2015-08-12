using UnityEngine;
using System.Collections;

public class MissileFirer : MonoBehaviour
{

	public GameObject missile;
	public float delay;
	private float timeSinceLastFired;

	// Use this for initialization
	void Start ()
	{
		timeSinceLastFired = delay;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeSinceLastFired -= Time.deltaTime;
		if (timeSinceLastFired <= 0f) {
			GameObject target = GameObject.FindWithTag ("Target");
			if (target != null) {
				GameObject fired = Instantiate (missile);
				TowerPosition tp = GetComponent<TowerPosition> ();
				fired.transform.position = new Vector3 (tp.x + .5f, 1f, tp.y + .5f);
				timeSinceLastFired = delay;
			}
		}
	}
}
