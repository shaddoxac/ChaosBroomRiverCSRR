using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour {
    public GameObject fireball;
	public GameObject dropBall;
    public float moveSpeed;
    public float delay;

    private float recharge = 0.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        MouseControl();
    }

    void MouseControl(){
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (recharge <= Time.time) {
				var aud = GetComponent<AudioSource> ();
				aud.Play ();
				GameObject fire = GameObject.Instantiate (fireball);
				fire.transform.position = transform.position;
				recharge = Time.time + delay;
			}
		} 

		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			GameObject drop = GameObject.Instantiate (dropBall) as GameObject;
			drop.transform.position = transform.position;
			drop.transform.Translate (Vector3.down * 5);
			FollowCam.S.poi = drop;
		}

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = Camera.main.transform.position.y;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        pos.z = mousePos3D.z;
        transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "EnemyProjectile" || collidedWith.tag == "Enemy"){
            //TODO lose life?
            Destroy(collidedWith);
            GameController.EndGame();
            Destroy(this.gameObject);
        }
    }
}
