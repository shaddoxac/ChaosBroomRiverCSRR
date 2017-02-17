using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public static int score = 0;
    private static bool gameOver = false;
    

    private static Text scoreText;

    // Use this for initialization
    void Start () {
        Invoke("CreateBroom", broomStart);
        Invoke("CreateTank", tankStart);
        Invoke("CreateSeeker", seekerStart);
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
		//if (player == null){
        //    EndGame();
        //}
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

    public static void UpdateScore(){
        scoreText.text = "Score: " + score;
    }

    public static void UpdateScore(int s){
        score += s;
        UpdateScore();
    }

    public static void EndGame(){
        gameOver = true;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        //TODO load new scene?
    }
}
