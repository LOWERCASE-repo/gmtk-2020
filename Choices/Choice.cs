using UnityEngine;

class Choice : MonoBehaviour {
	
	[SerializeField]
	Response[] responses;
	
	public bool Respond() {
		if (!Interviewer.instance.answered && !Interviewer.instance.locked) {
			Interviewer.instance.Enqueue(responses);
			return true;
		}
		return false;
	}
}
