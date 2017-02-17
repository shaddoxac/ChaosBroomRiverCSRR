using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBall : MonoBehaviour {

	public int minY;

	public float explosionRadius;
	public float explosionForce;

	public AudioClip explode;

	void Start() {
		var audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < minY) {
			KillSelf ();
		}
	}

	void OnCollisionEnter(Collision col) {
		var exp = GetComponent<ParticleSystem>();
		var audio = GetComponent<AudioSource> ();
		audio.clip = explode;
		audio.Play ();
		exp.Play();
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius);
		foreach (Collider hit in colliders) {
			Rigidbody r = hit.GetComponent<Rigidbody> ();
			if (r != null)
				r.AddExplosionForce (explosionForce, transform.position, explosionRadius);
		}
		Invoke ("KillSelf", 1f);
	}

	void KillSelf() {
		Destroy (this.gameObject);
	}
}
