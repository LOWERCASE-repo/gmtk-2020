using UnityEngine;

class CollisionChoice : Choice {
	
	void OnCollisionEnter2D() {
		// Debug.Log("OOF");
		Respond();
	}
	
	void OnTriggerEnter2D() {
		Respond();
	}
}
