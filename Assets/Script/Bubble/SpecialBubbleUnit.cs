﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class SpecialBubbleUnit : BubbleUnit {

	public CircleCollider2D rangeCollider;
	public BoxCollider2D lineCollider;

	private List<Transform> tempColliderList = new List<Transform>();


	public override void SetData (int ID)
	{
		GetComponent<Rigidbody2D>().isKinematic = false;	
		base.SetData (ID);

	}


	public void DealEffectCleanBubble(BubbleUnit bubble)
	{
		Debug.Log (bubble.name);
		bubble.ReduceHitCount ();
		BubbleManager.Instance.RecycleBubble(bubble);
	}

	void OnMouseDown() {

		if (BubbleManager.Instance.isCanClick == false) {
			return;
		}

		Debug.Log ("special monsedown");

		int type = IDTool.GetType (ID);
		int typeID = IDTool.GetTypeID (ID);

		if (type != 2) {
			Debug.LogError ("error type");
			return;
		} else {

			BubbleManager.Instance.scoreMulti=2f;

			if(typeID ==1)
			{
				CleanRow();
			}else if(typeID ==2)
			{
				CleanCol();
			}else if(typeID == 3)
			{
				CleanRowCol();
			}else if(typeID == 4)
			{
				CleanRange();
			}else if(typeID ==5)
			{
				BubbleManager.Instance.ClearSameColorBubble(this);
				this.ReduceHitCount ();
				BubbleManager.Instance.RecycleBubble (this);
			}else if(typeID ==6 )
			{
				BubbleManager.Instance.CleanAllBubble();
				this.ReduceHitCount ();
				BubbleManager.Instance.RecycleBubble (this);
			}
		    
			GetComponent<Rigidbody2D>().isKinematic = true;	
		}
	}

	private void CleanRow()
	{
		Transform left = Instantiate (lineCollider.transform);
		Transform right = Instantiate (lineCollider.transform);

		left.SetParent(transform);
		right.SetParent(transform);

		left.localPosition = Vector3.zero;
		right.localPosition = Vector3.zero;


		left.gameObject.SetActive (true);
		right.gameObject.SetActive (true);

		tempColliderList.Add (left);
		tempColliderList.Add (right);



		left.DOMoveX (-300f, 0.8f).SetEase(Ease.Linear);
		right.DOMoveX (300f, 0.8f).SetEase(Ease.Linear).OnComplete(CleanCollider);

	}
	private void CleanCol()
	{
		Transform up = Instantiate (lineCollider.transform);
		Transform down = Instantiate (lineCollider.transform);

		up.SetParent(transform);
		down.SetParent(transform);

		up.localPosition = Vector3.zero;
		down.localPosition = Vector3.zero;
		
		up.gameObject.SetActive (true);
		down.gameObject.SetActive (true);
		
		tempColliderList.Add (up);
		tempColliderList.Add (down);
		
		
		
		up.DOMoveY (500f, 0.8f).SetEase(Ease.Linear);
		down.DOMoveY (-500f, 0.8f).SetEase(Ease.Linear).OnComplete(CleanCollider);
	}

	private void CleanRowCol()
	{
		CleanRow ();
		CleanCol ();
	}

	private void CleanRange()
	{
		Transform range = Instantiate (rangeCollider.transform);
		range.SetParent(this.transform);
		range.localPosition = Vector3.zero;
		range.gameObject.SetActive (true);
		tempColliderList.Add (range);
		rangeCollider.transform.DOShakePosition (0.2f, new Vector3 (1f, 1f, 0f)).OnComplete (CleanCollider);
	}

	private void CleanCollider()
	{
		for (int i=0; i<tempColliderList.Count; ++i) {
			Destroy(tempColliderList[i].gameObject);
		}
		tempColliderList.Clear ();

		this.ReduceHitCount ();
		BubbleManager.Instance.RecycleBubble (this);
	}


}
