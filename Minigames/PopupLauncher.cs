using UnityEngine;
using UnityEngine.UI;
using System.Collections;

class PopupLauncher : MonoBehaviour {
	
	[SerializeField]
	Text[] texts;
	[SerializeField]
	Rigidbody2D[] rbs;
	int index = 0;
	int count;
	
	void Start() {
		count = texts.Length;
	}
	
	internal void Launch(string text) {
		texts[index].gameObject.SetActive(true);
		// texts[index].gameObject.enabled
		StartCoroutine(pewwish(index));
		index = ++index % count;
	}
	
	IEnumerator pewwish(int index) {
		yield return new WaitForSeconds(10f);
		texts[index].gameObject.SetActive(false);
	}
}
