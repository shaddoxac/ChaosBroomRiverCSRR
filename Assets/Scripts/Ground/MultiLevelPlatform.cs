using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class MultiLevelPlatform : MonoBehaviour {

	public GameObject block;
	public GameObject platform;

	public int blocks;

	public int maxLevels = 4;

	private Vector3 platformSize;
	private Vector3 blockSize;

	// Use this for initialization
	void Start () {
		platformSize = GetComponent<Renderer> ().bounds.size;
		blockSize = block.GetComponent<Renderer> ().bounds.size;
		float initialY = transform.position.y + platformSize.y / 2 + blockSize.y / 2;

		CreateBlocks (initialY);

		int levels = Random.Range (1, maxLevels);

		float platformY = initialY;
		for (int i = 1; i < levels; i++) {
			platformY += blockSize.y / 2 + platformSize.y / 2;
			CreatePlatform (platformY);
			platformY += blockSize.y / 2 + platformSize.y / 2; // + blockSize.y/2;
			CreateBlocks (platformY);
		}
		platformY += blockSize.y / 2 + platformSize.y / 2;
		CreatePlatform (platformY);
	}

	void CreatePlatform(float y) {
		var self = Instantiate (platform) as GameObject;
		self.transform.position = transform.position;
		var body = self.AddComponent<Rigidbody> ();
		body.useGravity = true;
		var pos = self.transform.position;
		pos.y = y;
		self.transform.position = pos;
	}

	void CreateBlocks(float y) {
		var botleft = transform.position - platformSize / 2;
		var topright = transform.position + platformSize / 2;

		topright.x -= 3 * blockSize.x;
		topright.z -= 3 * blockSize.z;

		botleft.x += 3 * blockSize.x;
		botleft.z += 3 * blockSize.z;

		List<Vector3> possiblePositions = new List<Vector3> ();

		float currentX = topright.x;
		float currentZ = topright.z;

		Vector3 possible;
		while (currentZ > botleft.z) {
			possible = new Vector3 (currentX, y, currentZ);
			possiblePositions.Add (possible);

			if (currentX < botleft.x) {
				currentX = topright.x;
				currentZ -= 2 * blockSize.z;
			} else {
				currentX -= 2 * blockSize.x;
			}
		}

		int initialCount = possiblePositions.Count;
		int randomIndex;
		for (int i = 0; i < blocks && i < initialCount; i++) {
			randomIndex = Random.Range (0, possiblePositions.Count);
			Instantiate (block, possiblePositions [randomIndex], Quaternion.identity);
			possiblePositions.RemoveAt (randomIndex);
		}

	}
}
