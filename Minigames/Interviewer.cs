using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

class Interviewer : MonoBehaviour {
	
	internal static Interviewer instance;
	internal int favour = 2;
	// 2 is perfect is good ending
	// 1 is a little tired and good ending
	// 0 or less is very tired and bad ending
	
	[SerializeField]
	Text text;
	[SerializeField]
	Image image;
	[SerializeField]
	Image eyebags;
	[SerializeField]
	Image finishedArrow;
	[SerializeField]
	PopupLauncher launcher;
	[SerializeField]
	AudioSource audio;
	[SerializeField]
	AudioClip talkSound;
	[SerializeField]
	Sprite[] bases = new Sprite[4]; // neutral, frown, smile, eyebrow
	[SerializeField]
	Sprite clearBags;
	[SerializeField]
	Sprite[] lightBags = new Sprite[4];
	[SerializeField]
	Sprite[] doomBags = new Sprite[4];
	Sprite[,] accents = new Sprite[4, 3]; // good, tired, done
	Queue<Response> responses;
	internal bool answered;
	internal bool locked;
	bool playSound;
	// AnimationCurve curve = new AnimationCurve(new KeyFrame(0f, 0f) new KeyFrame(1f, 1f));
	
	void Awake() {
		instance = this;
		responses = new Queue<Response>();
		NextQuestion();
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				if (j == 0) {
					accents[i, j] = clearBags;
				} else if (j == 1) {
					accents[i, j] = lightBags[i];
				} else {
					accents[i, j] = doomBags[i];
				}
			}
		}
		image.sprite = bases[0];
		eyebags.sprite = accents[0, 0];
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
		favour += response.deltaFavour;
		if (favour < 0) favour = 0;
		if (favour > 2) favour = 2;
		if (!string.IsNullOrEmpty(response.popup)) {
			launcher.Launch(response.popup);
		}
		this.text.text = "";
		int length = response.text.Length;
		int index = 0;
		Debug.Log(favour);
		image.sprite = bases[response.sprite];
		eyebags.sprite = accents[response.sprite, 2 - favour];
		do {
			char next = response.text[index];
			this.text.text = string.Concat(this.text.text, next);
			if (next != ' ' && playSound) {
				playSound = false;
				audio.PlayOneShot(talkSound);
			} else playSound = true;
			if (next == ',' || next == '.') yield return new WaitForSeconds(0.4f);
			yield return new WaitForSeconds(0.02f);
			index = this.text.text.Length;
		} while (index != length);
		locked = false;
		if (answered) finishedArrow.enabled = true;
	}
	
	void NextQuestion() {
		int index = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(index + 1);
		answered = false;
		Enqueue(new Response(questions[index], 0, "", 0));
		answered = false; // yes this is necessary dont question it
	}
	
	string[] questions = {
		"Tell me about yourself. What makes you unique?",
		"How do you handle stress?",
		"What motivates you?",
		"Tell me about your problem solving skills.",
		"Where do you see yourself in five years?",
		"Do you have any questions for me?",
		"Well, thank you for coming in. You can expect to hear from us in the next day or two.",
		" "
	};
}

[Serializable]
public struct Response {
	public Response(string text, int sprite, string popup, int deltaFavour) {
		this.text = text;
		this.sprite = sprite;
		this.popup = popup;
		this.deltaFavour = deltaFavour;
	}
	public string text;
	public int sprite;
	public string popup;
	public int deltaFavour;
}
