using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BubbleUnit : MonoBehaviour {
	public int ID = 0;
	public int SingleScore = 0;
	public int hitCount =1;
	public CircleCollider2D bubCollider;
	public Image bubbleImage;
	
   public virtual void SetData(int ID)
	{
		this.ID = ID;
		this.SingleScore = BubbleData.Instance.GetSingleScore (ID);

		string spriteName = BubbleData.Instance.GetSpriteName (ID);
		Sprite curSprite = SpriteManager.Instance.GetSprite (spriteName);
		bubbleImage.sprite = curSprite;
	}

	void OnMouseDown() {
		if (BubbleManager.Instance.isCanClick == false) {
			return;
		}

		BubbleManager.Instance.Clean (this);
	}

	public virtual void ReduceHitCount()
	{
		hitCount -= 1;
	}


}
