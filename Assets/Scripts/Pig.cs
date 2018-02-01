using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

	public float minSpeed = 10;
	public float maxSpeed = 5;
	public Sprite hurt;
	public GameObject boom;
	public GameObject score;

	private SpriteRenderer render;

	void Awake() {
		render = GetComponent<SpriteRenderer> ();
	}

	void OnCollisionEnter2D(Collision2D collision ) {
		var relativeV = collision.relativeVelocity.magnitude;
		if (relativeV > maxSpeed) {
			pigDead ();
		} else if (relativeV > minSpeed && relativeV < maxSpeed) {
			render.sprite = hurt;
		}
	}

	void pigDead() {
		Destroy (gameObject);
		Instantiate (boom, transform.position,Quaternion.identity);
		GameObject go = Instantiate (score, transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
		Destroy (go, 1f);
	}
}
