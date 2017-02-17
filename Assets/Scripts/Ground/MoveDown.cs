using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour {

	void FixedUpdate() {
		transform.Translate (Vector3.back * 0.05f);
	}
}
