using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float delay;
    public int life;
    public GameObject bullet;
    public bool angled;

    private Transform playerT;

	// Use this for initialization
	void Start () {
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        if (!angled) { InvokeRepeating("Shoot", 1f, delay); }
        else { InvokeRepeating("ShootAngled", 1f, delay); }
    }
	
	// Update is called once per frame
	void Update () {
	}

    void Shoot(){
        GameObject fire = GameObject.Instantiate(bullet);
        fire.transform.position = transform.position;
    }

    void ShootAngled(){
        GameObject fire = GameObject.Instantiate(bullet);
        fire.transform.position = transform.position;
        if (transform.position.x - 0.5 > playerT.transform.position.x) {
            Projectile proj = fire.GetComponent<Projectile>();
            proj.zSpeed *= .5f;
            proj.xSpeed = proj.zSpeed;
        }
        else if (transform.position.x + 0.5 < playerT.transform.position.x){
            Projectile proj = fire.GetComponent<Projectile>();
            proj.zSpeed *= .5f;
            proj.xSpeed = -proj.zSpeed;
        }
            
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "PlayerProjectile"){
            Destroy(collidedWith);
            life--;
            if (life <= 0){
                Destroy(this.gameObject);
            }
        }
    }
}
