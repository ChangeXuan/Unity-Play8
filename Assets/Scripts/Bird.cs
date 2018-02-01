using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	private bool isClick = false;
	[HideInInspector]
	public SpringJoint2D sp;
	private Rigidbody2D rg;

	public float maxDis = 3;
	public Transform rightPos;
	public Transform leftPos;
	public LineRenderer rightLine;
	public LineRenderer leftLine;



	void Awake() {
		sp = GetComponent<SpringJoint2D> ();
		rg = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		line ();
		if (isClick) {
			transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			transform.position += new Vector3 (0, 0, 10);
			transform.position -= new Vector3(0,0,Camera.main.transform.position.z);

			if (Vector3.Distance (transform.position, rightPos.position) > maxDis) {
				Vector3 pos = (transform.position - rightPos.position).normalized;
				pos *= maxDis;
				transform.position = pos + rightPos.position;
			}

		} else {
			
		}
	}

	void OnMouseDown() {
		isClick = true;
		rg.isKinematic = true;
	}

	void OnMouseUp() {
		isClick = false;
		rg.isKinematic = false;
		Invoke ("birdFly", 0.1f);
	}

	void birdFly() {
		sp.enabled = false;
	}

	void line() {
		rightLine.SetPosition (0, rightPos.position);
		rightLine.SetPosition (1, transform.position);

		leftLine.SetPosition (0, leftPos.position);
		leftLine.SetPosition (1, transform.position);
	}
}
