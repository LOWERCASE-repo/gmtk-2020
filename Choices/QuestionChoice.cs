using UnityEngine;

class QuestionChoice : Choice {
	
	[SerializeField]
	Response[] badResponses;
	
	void Update() {
		if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
		Vector2 pos = transform.position;
		Vector2 size = pos + ((RectTransform)transform).sizeDelta;
		Vector2 mousePos = MouseCursor.Pos;
		if (mousePos.x >= pos.x && mousePos.x <= size.x && mousePos.y >= pos.y && mousePos.y <= size.y) {
			if (Interviewer.instance.favour >= 2) Respond();
			else {
				if (!Interviewer.instance.answered && !Interviewer.instance.locked) {
					Interviewer.instance.Enqueue(badResponses);
					image.color = Color.gray.gamma.gamma;
				}
			}
		}
	}
}
