using UnityEngine;
using System.Collections;

public class IDTool  {

	public static int GetType(int ID)
	{
		int type = ID / 10;
		return type;
	}

	public static int GetTypeID(int ID)
	{
		int typeID = ID % 10;
		return typeID;
	}

}
