using UnityEngine;
using UnityEngine.UI;

class SlotChoice : Choice {
	
	bool stopped;
	float startTime;
	
	void Start() {
		startTime = Time.time;
	}
	
	void Update() {
		if (Time.time - startTime < 1.5f) return;
		if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
		stopped = true;
		if (transform.localPosition.y < 151f && transform.localPosition.y > 50f) {
			Respond();
		}
	}
	
	void FixedUpdate() {
		if (!stopped) {
			// pos = new Vector2(transform.position.x, transform.position.y - 2);
			transform.localPosition -= new Vector3(0f, 12.5f, 0f);
			if (transform.localPosition.y <= -200f) {
				transform.localPosition = new Vector3(0f, 400f, 0f);
			}
		}
	}
}
