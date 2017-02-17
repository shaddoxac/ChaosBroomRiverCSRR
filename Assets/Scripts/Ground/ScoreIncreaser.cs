using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncreaser : MonoBehaviour {

	public void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Water") {
			GameController.UpdateScore(5);
			Destroy (gameObject);
		}
	}
}
