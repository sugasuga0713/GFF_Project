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
	[Header("拾う距離")] [SerializeField] private float pickUpDistance = 1.75f;
	public List<List<Weapon>> baseObjectList = new List<List<Weapon>>();

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
		StartAddObject();
	}

	public Weapon GetObjectInRange(int areaNo,Vector3 pos)
	{
		int size = baseObjectList[areaNo].Count;
		Weapon obj = null;
		float distance = pickUpDistance;
		for(i = 0; i < size; i++)
		{
			if (baseObjectList[areaNo][i].IsHaved) continue; //プレイヤーが現在持っているオブジェクトはスルーする

			if(distance > Vector3.Distance(baseObjectList[areaNo][i].myTransform.position, pos))
			{
				obj = baseObjectList[areaNo][i];
				distance = Vector3.Distance(baseObjectList[areaNo][i].myTransform.position, pos);
			}
		}
		if (distance > pickUpDistance)
			return null;
		else
			return obj;
	}

	public void AddObject(int areaNo, Weapon obj)
	{
		baseObjectList[areaNo].Add(obj);
	}

	public void StartAddObject()
	{
		GameObject[] baseObjects = GameObject.FindGameObjectsWithTag("DynamicObject");
		for(i = 0;i<baseObjects.Length;i++)
		{
			AddObject(0, baseObjects[i].GetComponent<Weapon>());
		}
	}

	public void SetUp()
	{
		for(i = 0; i < area; i++)
		{
			baseObjectList.Add(new List<Weapon>());
		}
	}
}