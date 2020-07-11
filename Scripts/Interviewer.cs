using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

class Interviewer : MonoBehaviour {
	
	internal static Interviewer instance;
	
	[SerializeField]
	Text text;
	[SerializeField]
	Image image;
	[SerializeField]
	Sprite[] neutrals;
	Queue<Response> responses;
	internal bool answered;
	bool locked;
	
	void Awake() {
		instance = this;
		responses = new Queue<Response>();
		NextQuestion();
	}
	
	void Update() {
		if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
		if (!locked) {
			if (responses.Count == 0 && answered) NextQuestion();
			else if (responses.Count > 0) {
				StartCoroutine(Read());
			}
		}
	}
	
	internal void Enqueue(Response response) {
		responses.Enqueue(response);
		if (!locked && responses.Count == 1) StartCoroutine(Read());
	}
	
	IEnumerator Read() {
		locked = true;
		Response response = responses.Dequeue();
		this.text.text = "";
		int length = response.text.Length;
		int index = 0;
		image.sprite = response.sprite;
		do {
			char next = response.text[index];
			this.text.text = string.Concat(this.text.text, next);
			if (next == ',' || next == '.') yield return new WaitForSeconds(0.4f);
			yield return new WaitForSeconds(0.02f);
			index = this.text.text.Length;
		} while (index != length);
		locked = false;
	}
	
	void NextQuestion() {
		int index = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(index + 1);
		Enqueue(new Response(questions[index], neutrals[Saver.state.fatigue]));
		answered = false;
	}
	
	string[] questions = {
		"Tell me about yourself. What makes you unique?",
		"How do you handle stress?",
		"What motivates you?",
		"What skills do you bring to the table?",
		"What is your expected salary?",
		"Is that in dollars per year, hour or second?",
		"Where do you see yourself in five years?"
	};
}

[Serializable]
public struct Response {
	public Response(string text, Sprite sprite) {
		this.text = text;
		this.sprite = sprite;
	}
	public string text;
	public Sprite sprite;
}
