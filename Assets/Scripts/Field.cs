using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
	public Text text;
	public GameObject highlighter;
	public GameObject towerPrefab;
	public bool placing = true;
	private int[,] tilemap = {
		{4,4,4,4,4,4,4,4,4,4},
		{4,4,5,2,2,2,7,4,4,4},
		{4,4,12,4,4,4,12,4,5,2},
		{4,4,12,4,4,4,12,4,12,4},
		{4,4,12,4,4,4,12,4,12,4},
		{4,4,12,4,4,4,12,4,12,4},
		{4,4,12,4,5,2,10,2,15,4},
		{4,4,12,4,12,4,12,4,4,4},
		{4,4,12,4,13,2,15,4,4,4},
		{2,2,15,4,4,4,4,4,4,4}
	};

	// Update is called once per frame
	void Update ()
	{
		Vector2 pos;
		string hitname = GetMouseGridPosition (out pos);
		if (hitname!=null) {
			int curx = (int) Mathf.Floor (pos.x);
			int cury = (int) Mathf.Floor (pos.y);
			text.text = string.Format ("Cursor Square: {0}, {1}", curx, cury);
			highlighter.transform.position = new Vector3 (Mathf.Floor (pos.x) + .5f, 1f, Mathf.Floor (pos.y) + .5f);
			highlighter.SetActive (true);
			if (Input.GetMouseButtonDown (0)&&hitname=="Field"&&tilemap[cury,9-curx]==4) {
				bool isTowerHere = false;
				foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Tower")) {
					TowerPosition tower = obj.GetComponent<TowerPosition> ();
					if(tower.x==curx && tower.y==cury){
						if(!placing){
							Destroy(obj);
						}
						isTowerHere = true;
					}
				}
				if(!isTowerHere && placing)
					Instantiate(towerPrefab).transform.position = new Vector3(0.89f+curx, 0, 0.89f+cury);

			}
		} else {
			text.text = "Out of bounds!";
			highlighter.SetActive (false);
		}
	}

	public static string GetMouseGridPosition (out Vector2 pos)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		pos = new Vector2 ();
		if (Physics.Raycast (ray, out hit)) {
			pos = new Vector2 (hit.point.x, hit.point.z);
			return hit.transform.name;
		} else {
			return null;
		}
	
	}

	public void SetPlacing(bool value){
		placing = value;
	}
}
