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
		"question one",
		"question two",
		"question three"
	};
}
