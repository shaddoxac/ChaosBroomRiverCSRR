using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float delay;
    public GameObject bullet;
    public bool angled;

    private Transform playerT;

	// Use this for initialization
	void Start () {
        if (!angled) { InvokeRepeating("Shoot", 1f, delay); }
        else{
            playerT = GameObject.FindGameObjectWithTag("Player").transform;
            InvokeRepeating("ShootAngled", 1f, delay);
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    void Shoot(){
        GameObject fire = Instantiate(bullet);
        fire.transform.position = transform.position;
    }

    void ShootAngled(){
        GameObject fire = Instantiate(bullet);
        fire.transform.position = transform.position;
        if (transform.position.x - 1 > playerT.transform.position.x) {
            Projectile proj = fire.GetComponent<Projectile>();
            proj.zSpeed *= .5f;
            proj.xSpeed = proj.zSpeed;
        }
        else if (transform.position.x + 1 < playerT.transform.position.x){
            Projectile proj = fire.GetComponent<Projectile>();
            proj.zSpeed *= .5f;
            proj.xSpeed = -proj.zSpeed;
        }
            
    }
}
