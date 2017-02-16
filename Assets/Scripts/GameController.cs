using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject enemyBroom;
    public float leftAndRightEdge;
    public float top;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateBroom", 0f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateBroom(){
        GameObject br = GameObject.Instantiate(enemyBroom);
        Vector3 pos = new Vector3();
        pos.x = Random.Range(-leftAndRightEdge, leftAndRightEdge);
        pos.y = 0;
        pos.z = top;

        br.transform.position = pos;
    }
}
