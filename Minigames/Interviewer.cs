using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

class Interviewer : MonoBehaviour {
	
	internal static Interviewer instance;
	internal int favour = 0;
	
	[SerializeField]
	Text text;
	[SerializeField]
	Image image;
	[SerializeField]
	Image finishedArrow;
	[SerializeField]
	Sprite[] neutrals;
	Queue<Response> responses;
	internal bool answered;
	internal bool locked;
	// AnimationCurve curve = new AnimationCurve(new KeyFrame(0f, 0f) new KeyFrame(1f, 1f));
	
	void Awake() {
		instance = this;
		responses = new Queue<Response>();
		NextQuestion();
	}
	
	void Update() {
		// Debug.Log(answered + " " + locked);
		if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
		if (!locked) {
			if (responses.Count == 0 && answered) NextQuestion();
			else if (responses.Count > 0) {
				StartCoroutine(Read());
			}
		}
	}
	
	internal void Enqueue(params Response[] responses) {
		if (!locked && !answered) {
			foreach (Response response in responses) {
				this.responses.Enqueue(response);
			}
			StartCoroutine(Read());
			answered = true;
		}
	}
	
	IEnumerator Read() {
		finishedArrow.enabled = false;
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
		if (answered) finishedArrow.enabled = true;
	}
	
	void NextQuestion() {
		int index = SceneManager.GetActiveScene().buildIndex;
		if (index >= 7) return;
		SceneManager.LoadScene(index + 1);
		answered = false;
		Enqueue(new Response(questions[index], neutrals[0]));
		answered = false; // yes this is necessary dont question it
	}
	
	string[] questions = {
		"Tell me about yourself. What makes you unique?",
		"How do you handle stress?",
		"What motivates you?",
		"Tell me about your problem solving skills.",
		"Where do you see yourself in five years?",
		"Do you have any questions for me?",
		"Tell me about yourself. What makes you unique?"
	};
}

[Serializable]
public struct Response {
	public Response(string text, Sprite sprite) {
		this.text = text;
		this.sprite = sprite;
	} // TODO
	public string text;
	public Sprite sprite;
	// public string popup;
	// public int deltaFavour;
}
