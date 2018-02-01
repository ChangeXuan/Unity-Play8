using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<Bird> birds;
	public List<Pig> pigs;

	void initialized() {
		for (int i = 0; i < birds.Count; i++) {
			if (i == 0) {
				birds [i].enabled = true;
				birds [i].sp.enabled = true;
			} else {
				birds [i].enabled = false;
				birds [i].sp.enabled = false;
			}
		}
	}
}
