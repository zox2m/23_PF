using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TableDataManager : Singleton<TableDataManager>
{
	public List<TableLevels> levels { get; private set; }


	public TableDataManager()
	{
		this.levels = new List<TableLevels>();
	}


	public void load_all()
	{
		load_levels();
	}


	void load_levels()
	{
		TextAsset data = Resources.Load<TextAsset>("table/levels");
		ArrayList tables = XUtil.MiniJSON.jsonDecode(data.text) as ArrayList;

		for (int i = 0; i < tables.Count; ++i)
		{
			this.levels.Add(new TableLevels((Hashtable)tables[i]));
		}
	}
}
