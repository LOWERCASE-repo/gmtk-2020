using UnityEngine;

abstract class Choice : MonoBehaviour {
	
	[SerializeField]
	string text, sprite;
	
	protected void Respond() {
		Interviewer.instance.Respond(text, sprite);
	}
}
