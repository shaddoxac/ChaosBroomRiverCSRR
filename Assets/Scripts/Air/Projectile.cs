using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float xSpeed;
    public float zSpeed;
    public float top;
    public float bottom;
    public bool playerControlled;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += xSpeed * Time.deltaTime;
        pos.z += zSpeed * Time.deltaTime;
        transform.position = pos;

        if (pos.z > top)
        {
            Destroy(this.gameObject);
        }
        else if (pos.z < bottom){
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (playerControlled)
        {
            if (collidedWith.tag == "Enemy")
            {
                Enemy en = collidedWith.GetComponent<Enemy>();
                
                en.lives--;
                if (en.lives <= 0) {
                    GameController.UpdateScore(en.points);
                    Destroy(collidedWith);
                }
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (collidedWith.tag == "Player"){
                Destroy(collidedWith);
                GameController.EndGame();
                Destroy(this.gameObject);
            }
        }
    }
}
