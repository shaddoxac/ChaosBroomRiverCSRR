using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public float minX, maxX;
	public float y;
	public float z;

	public GameObject platform;

	public float frequency;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("MakeNewPlatform", 0, frequency);
	}
	
	void MakeNewPlatform() {
		Vector3 pos = new Vector3 (Random.Range (minX, maxX), y, z);
		Instantiate (platform, pos, Quaternion.identity);
	}
		
}
