using UnityEngine;

class Choice : MonoBehaviour {
	
	[SerializeField]
	Response[] responses;
	
	public void Respond() {
		foreach (Response response in responses) {
			Interviewer.instance.Enqueue(response);
		}
		Interviewer.instance.answered = true;
		Destroy(this);
	}
}
