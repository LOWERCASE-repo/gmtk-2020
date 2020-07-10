using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

static class Leaderboard {
	
	internal static List<Entry> Scores { get => wrapper.entry; }
	
	const string privateCode = "tKd5AQo5v0ihWEtuyuhQTAS8bo0WBG0kijvo8A8G64hg";
	const string publicCode = "5f087247377eda0b6ce253cc";
	const string url = "http://dreamlo.com/lb/";
	static Wrapper wrapper;
	
	/*
	StartCoroutine(Leaderboard.Upload(4892, "money"));
	StartCoroutine(Leaderboard.Refresh());
	yield return new WaitForSecondsRealtime(1f);
	for (int i = 0; i < Leaderboard.Scores.Count; i++) {
		Debug.Log(Leaderboard.Scores[i].name + Leaderboard.Scores[i].score);
	}
	*/
	
	internal static IEnumerator Upload(int score, string name) {
		UnityWebRequest www = UnityWebRequest.Get(url + privateCode + "/add/" + WWW.EscapeURL(name) + "/" + score);
		yield return www.SendWebRequest();
		if (!string.IsNullOrEmpty(www.error)) Debug.Log("fuck");
	}
	
	internal static IEnumerator Refresh() {
		UnityWebRequest www = UnityWebRequest.Get(url + publicCode + "/json/");
		yield return www.SendWebRequest();
		if (string.IsNullOrEmpty(www.error)) {
			wrapper.entry = new List<Entry>();
			string raw = www.downloadHandler.text;
			raw = raw.Substring(26, raw.Length - 28);
			JsonUtility.FromJsonOverwrite(raw, wrapper);
		} else Debug.Log("fuck");
	}
}

[Serializable]
public struct Entry {
	public string name, text, date;
	public int score, seconds;
}

[Serializable]
public struct Wrapper {
	public List<Entry> entry;
}
