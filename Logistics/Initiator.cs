using UnityEngine;

class Initiator : MonoBehaviour {
	private void Awake() {
		DontDestroyOnLoad(this.gameObject);
		transform.DetachChildren();
		Destroy(gameObject);
	}
}
