using UnityEngine;
using UnityEngine.SceneManagement;

class Looper : MonoBehaviour {
	
	[SerializeField]
	Response reset;
	
	[SerializeField]
	GameObject good, bad;
	
	void Awake() {
		Interviewer.instance.locked = false;
		Interviewer.instance.gameObject.SetActive(false);
		if (Interviewer.instance.favour >= 2) {
			good.SetActive(true);
			Debug.Log("good");
		} else {
			bad.SetActive(true);
			Debug.Log("bad");
		}
	}
	
	void Update() {
		if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
		Vector2 pos = transform.position;
		Vector2 size = pos + ((RectTransform)transform).sizeDelta;
		Vector2 mousePos = MouseCursor.Pos;
		if (mousePos.x >= pos.x && mousePos.x <= size.x && mousePos.y >= pos.y && mousePos.y <= size.y) {
			Interviewer.instance.gameObject.SetActive(true);
			SceneManager.LoadScene(1);
			Interviewer.instance.favour = 2;
			Interviewer.instance.Enqueue(reset);
			Interviewer.instance.answered = false;
			
		}
	}
}
