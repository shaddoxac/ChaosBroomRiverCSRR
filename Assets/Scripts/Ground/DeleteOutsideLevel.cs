using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOutsideLevel : MonoBehaviour {

	Vector2 topRight = new Vector2 (45, 25);
	Vector2 botLeft = new Vector2(-40, -25);
	
	// Update is called once per frame
	void Update () {
		Rect r = new Rect (botLeft, topRight - botLeft);
		if (!r.Contains (new Vector2(transform.position.x, transform.position.z))) {
			Destroy (gameObject);
		}
	}
}
