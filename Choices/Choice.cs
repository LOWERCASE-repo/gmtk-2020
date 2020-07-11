using UnityEngine;

class Choice : MonoBehaviour {
	
	[SerializeField]
	string text;
	[SerializeField]
	Sprite sprite;
	
	public void Respond() {
		Interviewer.instance.Respond(text, sprite);
	}
}
