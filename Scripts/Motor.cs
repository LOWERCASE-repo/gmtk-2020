using UnityEngine;

class Motor : MonoBehaviour {
	
	[SerializeField]
	private float speed = 10f;
	[SerializeField]
	private float thrust = 10f;
	[SerializeField]
	private Rigidbody2D rb;
	[SerializeField]
	private Animator animator;
	
	internal void Move(Vector2 target) {
		target = Predict(target, -rb.velocity, speed);
		MoveDir(target - rb.position);
	}
	
	internal void MoveDir(Vector2 dir) {
		rb.drag = thrust;
		Vector2 force = dir.normalized * thrust * speed;
		rb.AddForce(force);
	}
	
	private Vector2 Predict(Vector2 target, Vector2 relVel, float speed) {
		Vector2 dir = target - rb.position;
		float a = speed * speed - relVel.sqrMagnitude;
		float b = Vector2.Dot(dir, relVel);
		float det = b * b + a * dir.sqrMagnitude;
		
		if (det < 0f) return target;
		det = Mathf.Sqrt(det);
		float timeA = b + det;
		float timeB = b - det;
		
		bool validA = (timeA > 0f);
		bool validB = (timeB > 0f);
		if (validA && validB) target += relVel / a * Mathf.Min(timeA, timeB);
		else if (validA) target += relVel / a * timeA;
		else if (validB) target += relVel / a * timeB;
		return target;
	}
}
