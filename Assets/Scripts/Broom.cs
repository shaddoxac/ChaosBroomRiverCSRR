using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour {
    public GameObject fireball;
    public float moveSpeed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //KeyboardControl();
        MouseControl();
    }

    void KeyboardControl() {
        float xVelocity = 0.0f;
        float yVelocity = 0.0f;
        if (Input.GetKeyDown(KeyCode.Space)) {
            //TODO launch fireball
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
            xVelocity += moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            yVelocity -= moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
            xVelocity -= moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            yVelocity -= moveSpeed;
        }
        Vector3 pos = transform.position;
        pos.x = xVelocity * Time.deltaTime;
        pos.y = yVelocity * Time.deltaTime;
        //TODO check in bounds
        transform.position = pos;
    }

    void MouseControl(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            GameObject fire = GameObject.Instantiate(fireball);
            fire.transform.position = transform.position;
        }
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        pos.y = mousePos3D.y;
        transform.position = pos;
    }
}
