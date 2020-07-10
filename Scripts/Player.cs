using UnityEngine;
using System.Collections;

class Player : MonoBehaviour {
	
	[SerializeField]
	private Motor motor;
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private Camera cam;
	
	// Vector2 mousePos = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
	
	private Vector2 moveDir;
	
	private void FixedUpdate() {
		moveDir = new Vector2(Input.GetAxisRaw("Horz"), Input.GetAxisRaw("Vert"));
		motor.MoveDir(moveDir);
	}
}
