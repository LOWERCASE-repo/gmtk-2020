using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

class Interviewer : MonoBehaviour {
	
	internal static Interviewer instance;
	
	[SerializeField]
	Text text;
	[SerializeField]
	Image image;
	
	[SerializeField]
	Sprite[] neutrals;
	
	string targetText;
	bool scrolling;
	bool ready;
	
	void Awake() {
		instance = this;
		NextQuestion();
	}
	
	void Update() {
		if (ready && Input.GetKeyDown(KeyCode.Mouse0)) {
			NextQuestion();
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			Debug.Log(Saver.state.fatigue);
		}
	}
	
	IEnumerator Scroll(string text) {
		this.text.text = "";
		
	}
	
	internal void Respond(string text, Sprite sprite) {
		this.text.text = text;
		image.sprite = sprite;
		ready = true;
	}
	
	void NextQuestion() {
		int index = SceneManager.GetActiveScene().buildIndex;
		this.text.text = questions[index];
		SceneManager.LoadScene(index + 1);
		ready = false;
		image.sprite = neutrals[Saver.state.fatigue];
	}
	
	string[] questions = {
		"Tell me about yourself. What makes you unique?",
		"... No need to be nervous.",
		"What skills do you bring to the table?",
		"What is your expected salary?",
		"Is that in dollars per year, hour or second?",
		"What motivates you?",
		"Where do you see yourself in five years?"
	};
}
