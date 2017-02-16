using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour {
    public float xSpeed;
    public float zSpeed;
    public float buffer;

    public float bottom;

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void Update()
    {
        Vector3 pos = transform.position;
        float playerx = player.transform.position.x;
        float curXSpeed;
        if (pos.x + buffer> playerx){
            curXSpeed = -Mathf.Abs(xSpeed);
        }
        else if (pos.x - buffer< playerx){
            curXSpeed = Mathf.Abs(xSpeed);
        }
        else{
            //float diff = pos.x - playerx;
            //curXSpeed = (Mathf.Abs(xSpeed)) * diff;
            curXSpeed = 0f;
        }
        pos.x += curXSpeed * Time.deltaTime;
        pos.z -= zSpeed * Time.deltaTime;
        if (pos.z < bottom) { Destroy(this.gameObject); }
        transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Enemy")
        {
            xSpeed = -Mathf.Abs(xSpeed);
        }
    }
}
