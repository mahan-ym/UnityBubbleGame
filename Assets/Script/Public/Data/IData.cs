using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IData{

	protected Hashtable DataTable;
	
	int DataRow;
	
	protected void InitData(string fileName)
	{
		DataTable = new Hashtable();
		TextAsset binAsset = Resources.Load (fileName, typeof(TextAsset)) as TextAsset;

		string[] lineArray = binAsset.text.Split ('\r');
		string[][] levelArray = new string [lineArray.Length][];
		for(int i =0;i < lineArray.Length; i++)
		{
			levelArray[i] = lineArray[i].Split (',');
		}
		int nRow = levelArray.Length;
		int nCol = levelArray[0].Length;
		
		DataRow = nRow - 1;
		
		for (int i = 1; i < nRow; ++i) 
		{
			if(levelArray[i][0]=="\n" || levelArray[i][0]=="")
			{
				nRow--;
				DataRow = nRow - 1;
				continue;
			}
			
			string id = levelArray[i][0].Trim();
			
			for (int j = 1; j < nCol; ++j) 
			{  
				DataTable.Add(levelArray[0][j] + "_" + id, levelArray[i][j]);
			}
		}
	}
	
	public int GetDataRow() {
		return DataRow;
	}
	
	protected virtual string GetProperty(string name, int id)
	{
		return GetProperty(name, id.ToString());
	}
	
	protected virtual string GetProperty(string name, string id)
	{
		string key = name + "_" + id;
		if(DataTable.ContainsKey(key))
			return DataTable[key].ToString();
		else
			return "";
	}
	
	public void JustInit(){}
}