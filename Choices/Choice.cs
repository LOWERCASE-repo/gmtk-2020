using UnityEngine;
using UnityEngine.UI;

class Choice : MonoBehaviour {
	
	[SerializeField]
	Image image;
	[SerializeField]
	Response[] responses;
	
	public bool Respond() {
		if (!Interviewer.instance.answered && !Interviewer.instance.locked) {
			Interviewer.instance.Enqueue(responses);
			image.color = Color.gray.gamma.gamma;
			return true;
		}
		return false;
	}
}
