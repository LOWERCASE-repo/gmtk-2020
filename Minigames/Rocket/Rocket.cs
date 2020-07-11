using UnityEngine;
using System.Collections;

class Rocket : MonoBehaviour {
	
	[SerializeField]
	private Motor motor;
	bool active;
	
	private void Update() {
		if (Input.GetAxisRaw("Vert") > 0f) {
			active = true;
		}
	}
	
	private void FixedUpdate() {
		if (active) motor.MoveDir(transform.up); //  - transform.position
		transform.rotation = transform.rotation.Rotate(Input.GetAxis("Horz") * 2f);
		// moveDir = new Vector2(, Input.GetAxisRaw("Vert"));
		// motor.MoveDir(moveDir);
	}
}
