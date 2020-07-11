using UnityEngine;

class Choice : MonoBehaviour {
	
	[SerializeField]
	string text, sprite;
	
	public void Respond() {
		Interviewer.instance.Respond(text, sprite);
	}
}
