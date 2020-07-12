using UnityEngine;
using System.Collections;

class Rocket : MonoBehaviour {
	
	[SerializeField]
	Motor motor;
	bool active;
	Camera cam;
	
	void Awake() {
		cam = Camera.main;
		active = true;
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			active = true;
		}
	}
	
	void FixedUpdate() {
		if (!active) return;
		Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		Quaternion target = (-45f).Rot() * Quaternion.LookRotation(Vector3.forward, dir);
		float sign = Mathf.Sign(target.eulerAngles.z - transform.rotation.eulerAngles.z - 180f);
		transform.rotation *= (sign * 10f).Rot();
		motor.MoveDir(45f.Rot() * transform.up);
	}
}
