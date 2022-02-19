using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoneBubbleUnit : BubbleUnit {

	public Text HitText;
	public override void SetData (int ID)
	{
		base.SetData (ID);

		hitCount = Random.Range (2, 6);
		HitText.text = hitCount.ToString ();
	}

	public override void ReduceHitCount ()
	{
		base.ReduceHitCount ();

		HitText.text = hitCount.ToString ();

	}

	void OnMouseDown() {
		if (BubbleManager.Instance.isCanClick == false) {
			return;
		}
	}
}
