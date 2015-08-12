using UnityEngine;
using System.Collections;

public class TowerPosition : MonoBehaviour {

	[SerializeField] public int x;
	[SerializeField] public int y;

	// Use this for initialization
	void Start () {
		x = (int) Mathf.Floor (transform.position.x);
		y = (int) Mathf.Floor (transform.position.z);
	}
}
