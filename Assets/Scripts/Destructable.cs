using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
    public int life;
    public int points;

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Player")
        {
            Destroy(collidedWith);
            Destroy(this.gameObject);
        }
        else if (collidedWith.tag == "PlayerProjectile")
        {
            life--;
            if (life <= 0){
                Destroy(collidedWith);
                GameController.score += points;
                GameController.UpdateScore();
                Destroy(this.gameObject);
            }
        }
    }
}
