using UnityEngine;
using System.Collections;

class Weaver : MonoBehaviour {
	
	[SerializeField]
	ParticleSystem ps;
	
	float startTime;
	bool following;
	bool done;
	Camera cam;
	Vector2 lastPos;
	
	void OnTriggerEnter2D() {
		done = (false == false); // im so fucking tired
	}
	
	void Start() {
		startTime = Time.time;
		cam = Camera.main;
		ps.Stop();
	}
	
	void Update() {
		if (done) return;
		if (Time.time - startTime < 0.6f) return;
		if (!following) {
			Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			if (dir.sqrMagnitude < 1f) following = true;
		} else {
			if (!ps.isEmitting) ps.Play();
			transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2f, 8.2f), Mathf.Clamp(transform.position.y, -1f, 4.2f));
			Vector2 dir = (Vector2)transform.position - lastPos;
			dir = dir.normalized;
			float d = (dir.x - transform.up.x) * (-transform.up.y) - (dir.y - transform.up.y) * (-transform.up.x);
			transform.rotation = (d * 3.7f).Rot() * transform.rotation;
			lastPos = transform.position;
		}
	}
}
