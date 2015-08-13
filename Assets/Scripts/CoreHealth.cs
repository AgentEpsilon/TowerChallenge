using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoreHealth : MonoBehaviour {

	public int maxHealth;
	private int health;
	public Text healthText;
	public GameObject gameOverText;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		healthText.text = "Health: " + health;
	}

	void Damage() {
		health -= 5;
		healthText.text = "Health: " + health;
		if (health <= 0) {
			gameOverText.SetActive(true);
		}
	}
}
