//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : ManagedUpdateBehaviour
{
	#region 変数
	public enum BulletType
	{
		NONE = -1, SMALLBULLET = 0, BIGBULLET = 1
	}
	#region パラメータ

	#endregion

	#region キャッシュ
	[System.SerializableAttribute]
	public class ValueList
	{
		[System.NonSerialized] public List<BaseBullet> list = new List<BaseBullet>();
		[System.NonSerialized] public Transform parent = null;
		public GameObject bulletPrefab = null;
	}

	//Inspectorに表示される
	[Header("弾の設定")] [SerializeField]
	private List<ValueList> bulletList = new List<ValueList>();

	int i;

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
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public override void UpdateMe()
    {
    
    }

    /// <summary>
    /// 固定更新処理
    /// </summary>
	public override void FixedUpdateMe()
	{

	}

	/// <summary>
	/// 
	/// </summary>
	public BaseBullet GetBullet(BulletType bulletType)
	{
		int bulletNo = (int)bulletType;
		if (bulletNo == -1) return null;

		int count = bulletList[bulletNo].list.Count;
		for(i = 0;i<count;i++)
		{
			if (!bulletList[bulletNo].list[i].ActiveSelf())
			{
				return bulletList[bulletNo].list[i];
			}
		}
		return null;
	}

	public BaseBullet CreateBullet(BulletType bulletType)
	{
		int bulletNo = (int)bulletType;
		if (bulletNo == -1) return null;

		int count = bulletList[bulletNo].list.Count;
		for (i = 0; i < count; i++)
		{
			if (!bulletList[bulletNo].list[i].ActiveSelf())
			{
				return bulletList[bulletNo].list[i];
			}
		}
		if (bulletList[bulletNo].list.Count == 0)
		{
			GameObject obj = new GameObject(bulletType.ToString());
			obj.transform.parent = myTransform;
			bulletList[bulletNo].parent = obj.transform;
		}
		GameObject instance = Instantiate(bulletList[bulletNo].bulletPrefab) as GameObject;
		BaseBullet bulletScript = instance.GetComponent<BaseBullet>();
		instance.SetActive(false);
		instance.transform.parent = bulletList[bulletNo].parent;
		bulletList[bulletNo].list.Add(bulletScript);
		return bulletScript;
	}
}