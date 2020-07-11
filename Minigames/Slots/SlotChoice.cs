using UnityEngine;
using UnityEngine.UI;

class SlotChoice : Choice {
	
	bool stopped;
	
	void Update() {
		if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
		stopped = true;
		if (transform.localPosition.y < 151f && transform.localPosition.y > 50f) {
			Respond();
		}
	}
	
	void FixedUpdate() {
		if (!stopped) {
			// pos = new Vector2(transform.position.x, transform.position.y - 2);
			transform.localPosition -= new Vector3(0f, 20f, 0f);
			if (transform.localPosition.y <= -300f) {
				transform.localPosition = new Vector3(0f, 300f, 0f);
			}
		}
	}
}
