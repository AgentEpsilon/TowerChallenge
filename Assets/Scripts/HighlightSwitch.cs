using UnityEngine;
using System.Collections;

public class HighlightSwitch : MonoBehaviour {
	public Material placingHighlight;
	public Material deletingHighlight;
	private Renderer ren;

	// Use this for initialization
	void Start () {
		ren = GetComponent<Renderer> ();
		ren.material = placingHighlight;
	}

	public void SetDeleting(bool isDeleting){
		ren.material = isDeleting ? deletingHighlight : placingHighlight;
	}
}
