using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

class MouseCursor : MonoBehaviour {
	
	static MouseCursor instance;
	internal static Vector2 Pos { get => instance.transform.position; }
	
	[SerializeField]
	Camera cam;
	Vector3 prevPos;
	Vector2 lerpPos;
	
	void Awake() {
		instance = this;
		Cursor.visible = false;
		StartCoroutine(Fidget());
	}
	
	void Update() {
		lerpPos += (Vector2)(Input.mousePosition - prevPos);
		prevPos = Input.mousePosition;
	}
	
	IEnumerator Fidget() {
		if (SceneManager.GetActiveScene().buildIndex == 2) {
			lerpPos = Input.mousePosition + (Vector3)(Random.insideUnitCircle * 100);
			float start = Time.fixedTime;
			for (float i = 0f; i < 0.2f; i = Time.fixedTime - start) {
				transform.position = Vector2.Lerp(transform.position
				, lerpPos, i / 0.2f);
				yield return null;
			}
		} else {
			transform.position = Input.mousePosition;
			yield return null;
		}
		StartCoroutine(Fidget());
	}
}
