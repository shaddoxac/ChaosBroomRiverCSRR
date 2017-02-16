using UnityEngine;

public class MovingAI : MonoBehaviour {
    public float xspeed;
    public float yspeed;
    public float leftAndRightEdge;
    public float chanceToChangeDirections;
    public float bottom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += xspeed * Time.deltaTime;
        pos.y -= yspeed * Time.deltaTime;
        if (pos.y < bottom) { Destroy(this.gameObject); }
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            xspeed = Mathf.Abs(xspeed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            xspeed = -Mathf.Abs(xspeed);
        }
       }
}
