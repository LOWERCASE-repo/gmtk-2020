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
	
	// private IEnumerator Start() {
	// 	// StartCoroutine(Leaderboard.Upload(4892, "money"));
	// 	StartCoroutine(Leaderboard.Refresh());
	// 	yield return new WaitForSecondsRealtime(1f);
	// 	for (int i = 0; i < Leaderboard.Scores.Count; i++) {
	// 		Debug.Log(Leaderboard.Scores[i].name + Leaderboard.Scores[i].score);
	// 	}
	// }
	
	private Vector2 moveDir;
	
	private void FixedUpdate() {
		moveDir = new Vector2(Input.GetAxisRaw("Horz"), Input.GetAxisRaw("Vert"));
		motor.MoveDir(moveDir);
	}
}
