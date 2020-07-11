using UnityEngine;

class MouseCursor : MonoBehaviour {
	
	static MouseCursor instance;
	internal static Vector2 Pos { get => instance.transform.position; }
	
	[SerializeField]
	Camera cam;
	
	void Awake() {
		instance = this;
		Cursor.visible = false;
	}
	
	void Update() {
		transform.position = Input.mousePosition;
	}
}
