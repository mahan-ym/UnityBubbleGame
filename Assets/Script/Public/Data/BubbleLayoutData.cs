using UnityEngine;
using System.Collections;

public class BubbleLayoutData : IData {

	static string dataName="";
	static BubbleLayoutData _instance = null;
	public static BubbleLayoutData Instance{
		get{
			if(_instance == null)
			{
				_instance = new BubbleLayoutData();
				dataName="Data/BubbleLayoutData";
				_instance.InitData(dataName);
			}
			return _instance;
		}
	}
	
	public void Refresh()
	{
		InitData (dataName);
	}

	public string GetData(int id)
	{
		return GetProperty ("Data",id);
	}

	public string GetDes(int id)
	{
		return GetProperty ("Des",id);
	}
}
