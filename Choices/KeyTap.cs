using UnityEngine;

class KeyTap : Choice {
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			Respond();
		}
	}
}
