using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float delay;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Shoot", 1f, delay);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void Shoot(){
        GameObject fire = GameObject.Instantiate(bullet);
        fire.transform.position = transform.position;
    }
}
