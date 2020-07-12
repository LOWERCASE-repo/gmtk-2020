using UnityEngine;
using UnityEngine.SceneManagement;

class Looper : MonoBehaviour {
	
	void Update() {
		if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
		Vector2 pos = transform.position;
		Vector2 size = pos + ((RectTransform)transform).sizeDelta;
		Vector2 mousePos = MouseCursor.Pos;
		if (mousePos.x >= pos.x && mousePos.x <= size.x && mousePos.y >= pos.y && mousePos.y <= size.y) {
			SceneManager.LoadScene(1);
			Interviewer.instance.favour = 0;
		}
	}
}
