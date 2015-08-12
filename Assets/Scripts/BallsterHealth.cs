using UnityEngine;
using System.Collections;

public class BallsterHealth : MonoBehaviour {
	public float maxHealth;
	private float health;
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}

	void Damage(float d){
		health -= d;
		if (health <= 0f)
			Destroy (gameObject);
	}
}
