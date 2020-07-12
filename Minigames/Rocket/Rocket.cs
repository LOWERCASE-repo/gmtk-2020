using UnityEngine;
using System.Collections;

class Rocket : MonoBehaviour {
	
	[SerializeField]
	Motor motor;
	[SerializeField]
	ParticleSystem ps;
	bool active;
	Camera cam;
	bool turnable;
	float startTime;
	
	void Start() {
		startTime = Time.time;
	}
	
	void Awake() {
		cam = Camera.main;
		active = true;
	}
	
	void Update() {
		if (Time.time - startTime < 1f) return;
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			active = true;
		}
	}
	
	void OnCollisionStay2D() {
		turnable = false;
	}
	
	void OnCollisionExit2D() {
		turnable = true;
	}
	
	void FixedUpdate() {
		if (!active) return;
		if (turnable) {
			Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			float d = (dir.x - transform.up.x) * (-transform.up.y) - (dir.y - transform.up.y) * (-transform.up.x);
			transform.rotation = (d * 0.5f).Rot() * transform.rotation;
		}
		if (Input.GetKey(KeyCode.Mouse0)) {
			motor.MoveDir(transform.up);
			if (!ps.isEmitting) ps.Play();
		} else {
			ps.Stop();
		}
	}
}
