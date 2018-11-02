//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ
	[Header("区画の数")] [SerializeField] private int area = 9;
	public List<List<BaseObject>> baseObjectList = new List<List<BaseObject>>();


	#endregion

	#region キャッシュ
	private int i;
	#endregion

	#endregion

	#region プロパティ

	#endregion

	/// <summary>
	/// 初期化処理
	/// </summary>
	protected override void Initialize()
	{
		base.Initialize();
		SetUp();
		
	}

	public BaseObject GetObjectInRange(int areaNo,Vector3 pos)
	{
		int size = baseObjectList[areaNo].Count;
		BaseObject obj = baseObjectList[areaNo][0];
		float distance = Vector3.Distance(baseObjectList[areaNo][0].myTransform.position,pos);
		for(i = 0; i < size; i++)
		{
			if(distance > Vector3.Distance(baseObjectList[areaNo][i].myTransform.position, pos))
			{
				obj = baseObjectList[areaNo][i];
				distance = Vector3.Distance(baseObjectList[areaNo][i].myTransform.position, pos);
			}
		}
		return obj;
	}

	public void AddObject(int areaNo,BaseObject obj)
	{
		baseObjectList[areaNo].Add(obj);
	}

	public void SetUp()
	{
		for(i = 0; i < area; i++)
		{
			baseObjectList.Add(null);
		}
	}
}