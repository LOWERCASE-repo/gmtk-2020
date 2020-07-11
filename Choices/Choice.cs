using UnityEngine;

class Choice : MonoBehaviour {
	
	[SerializeField]
	Response[] responses;
	
	public void Respond() {
		Interviewer.instance.Enqueue(responses);
		Interviewer.instance.answered = true;
	}
}
