using UnityEngine;
using UnityEngine.UI;
using System.Collections;

class PopupLauncher : MonoBehaviour {
	
	[SerializeField]
	Text text;
	[SerializeField]
	Transform image;
	[SerializeField]
	Text text2;
	[SerializeField]
	Transform image2;
	bool yote;
	
	AnimationCurve curve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f, 0f, 0f, 1f, 1f), new Keyframe(1f, 0f));
	
	internal void Launch(string text) {
		yote = !yote;
		if (yote) this.text.text = text;
		else text2.text = text;
		StartCoroutine(YEET());
	}
	
	IEnumerator YEET() {
		float start = Time.fixedTime;
		Transform yeetee = yote ? image : image2;
		for (float i = 0f; i < 2f; i = Time.fixedTime - start) {
			float y = curve.Evaluate(i / 2f) * -250f + 440f;
			yeetee.localPosition = new Vector3(0f, y, 0f);
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}
}
