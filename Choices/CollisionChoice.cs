using UnityEngine;

class CollisionChoice : Choice {
	
	void OnCollisionEnter2D() {
		Respond();
	}
}
