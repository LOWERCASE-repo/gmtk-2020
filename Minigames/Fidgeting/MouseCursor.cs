using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

class MouseCursor : MonoBehaviour {
	
	static MouseCursor instance;
	internal static Vector2 Pos { get => instance.transform.position; }
	
	[SerializeField]
	Camera cam;
	[SerializeField]
	Image image;
	Vector2 prevPos;
	Vector2 lerpPos;
	bool following;
	
	void Awake() {
		instance = this;
		Cursor.visible = false;
		SceneManager.activeSceneChanged += OnSceneChange;
		following = true;
	}
	
	void Update() {
		if (following) {
			transform.position = Input.mousePosition;
			prevPos = Input.mousePosition;
		}
	}
	
	void OnSceneChange(Scene current, Scene next) {
		switch (next.buildIndex) {
			case 1:
			following = true;
			Cursor.visible = false;
			break;
			case 2:
			following = false;
			StartCoroutine(Fidget());
			break;
			case 3:
			StopAllCoroutines();
			Cursor.visible = true;
			image.enabled = false;
			break;
			case 4:
			break;
			
		}
	}
	
	IEnumerator Fidget() {
		lerpPos = Input.mousePosition + (Vector3)(Random.insideUnitCircle.normalized * 100);
		float start = Time.fixedTime;
		for (float i = 0f; i < 0.2f; i = Time.fixedTime - start) {
			lerpPos += (Vector2)Input.mousePosition - prevPos;
			transform.position = Vector2.Lerp(transform.position, lerpPos, i / 0.2f);
			prevPos = Input.mousePosition;
			yield return null;
		}
		StartCoroutine(Fidget());
	}
}
