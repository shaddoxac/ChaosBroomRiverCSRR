using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

	public static FollowCam S;

	public float easing = 0.05f;
	public float minHeight = -10;

	public GameObject poi;

	private Vector3 initial;

	void Start() {
		initial = transform.position;
	}

	void Awake() {
		S = this;
	}

	void FixedUpdate() {
		Vector3 destination;

		if (poi == null) {
			destination = initial;
		} else {
			destination = poi.transform.position;
			if (poi.tag == "DropBall") {
				if (poi.GetComponent<Rigidbody>().IsSleeping() ) {
					poi = null;
					return;
				}
			}
		}

		destination.y = Mathf.Max (minHeight, destination.y);

		destination = Vector3.Lerp(transform.position, destination, easing);
		transform.position = destination;
		this.GetComponent<Camera>().orthographicSize = destination.y + 10;
	}

}
