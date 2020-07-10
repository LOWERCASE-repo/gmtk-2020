using UnityEngine;

class KeyTap : MonoBehaviour {
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			NextQuestion();
		}
	}
	
}
