using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FreezeBubbleUnit : BubbleUnit {

	public Text HitText;
	public Image freezeImg;

   public override void SetData (int ID)
	{
		base.SetData (ID);

		hitCount = 2;// Random.Range (2, 6);
		HitText.text = hitCount.ToString ();

		freezeImg.gameObject.SetActive(true);
	}

	public override void ReduceHitCount ()
	{
		base.ReduceHitCount ();

		HitText.text = hitCount.ToString ();

		if (hitCount < 1) {
			freezeImg.gameObject.SetActive(false);
		}
	}
	void OnMouseDown() {
		if (BubbleManager.Instance.isCanClick == false) {
			return;
		}
		BubbleManager.Instance.Clean (this);
	}
}
