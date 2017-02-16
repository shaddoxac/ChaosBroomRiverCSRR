using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed;
    public float top;
    public float bottom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.z += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.z > top)
        {
            Destroy(this.gameObject);
        }
        else if (pos.z < bottom){
            Destroy(this.gameObject);
        }
    }
}
