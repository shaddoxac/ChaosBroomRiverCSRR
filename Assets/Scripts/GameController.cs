using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject enemyBroom;
    public GameObject tank;
    public GameObject seeker;
    public float leftAndRightEdge;
    public float top;
    public float broomStart;
    public float minBroomDelay;
    public float maxBroomDelay;
    public float tankStart;
    public float minTankDelay;
    public float maxTankDelay;
    public float seekerStart;
    public float minSeekerDelay;
    public float maxSeekerDelay;
    public float delayRate;

    private GameObject player;
    private bool gameOver = false;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("CreateBroom", broomStart);
        Invoke("CreateTank", tankStart);
        Invoke("CreateSeeker", seekerStart);
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null){
            gameOver = true;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies){
                Destroy(enemy);
            }
            //TODO load new scene?
        }
	}

    void CreateBroom(){
        if (gameOver) { return; }
        Create(enemyBroom);
        Invoke("CreateBroom", Random.Range(minBroomDelay, maxBroomDelay));
        minBroomDelay *= delayRate;
        maxBroomDelay *= delayRate;
    }

    void CreateTank(){
        if (gameOver) { return; }
        Create(tank);
        Invoke("CreateTank", Random.Range(minTankDelay, maxTankDelay));
        minTankDelay *= delayRate;
        maxTankDelay *= delayRate;
    }

    void CreateSeeker()
    {
        if (gameOver) { return; }
        Create(seeker);
        Invoke("CreateSeeker", Random.Range(minSeekerDelay, maxSeekerDelay));
        minSeekerDelay *= delayRate;
        maxSeekerDelay *= delayRate;
    }

    void Create(GameObject o){
        if (gameOver) { return; }
        GameObject inst = GameObject.Instantiate(o);
        Vector3 pos = new Vector3();
        pos.x = Random.Range(-leftAndRightEdge, leftAndRightEdge);
        pos.y = 0;
        pos.z = top;

        inst.transform.position = pos;
    }
}
