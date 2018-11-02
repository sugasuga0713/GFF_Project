//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedManager : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ
	private bool canUseLeftHand = true; //左手を使えるかどうか
	private bool canUseRightHand = true; //右手を使えるかどうか

	private BaseObject objectLeft; //左手で持っているオブジェクト
	private BaseObject objectRight; //右手で持っているオブジェクト
    #endregion

    #region キャッシュ

    #endregion

    #endregion

    #region プロパティ
	public bool CanUseLeftHand
	{
		get
		{
			return canUseLeftHand;
		}
	}
	public bool CanUseRightHand
	{
		get
		{
			return canUseRightHand;
		}
	}

	public BaseObject ObjectLeft
	{
		get
		{
			return objectLeft;
		}
	}
	public BaseObject ObjectRight
	{
		get
		{
			return objectRight;
		}
	}
	#endregion

	public void PickUp(bool left,BaseObject obj)
	{
		if (left)
		{
			canUseLeftHand = false;
			objectLeft = obj;
		}
		else
		{
			canUseRightHand = false;
			objectRight = obj;
		}
	}

	public int GetGrossWeight()
	{
		int weight = 0;
		if (!canUseLeftHand)
		{
			weight += objectLeft.MyWeight;
		}
		if(!canUseRightHand)
		{
			weight += objectRight.MyWeight;
		}

		return weight;
	}

	/// <summary>
	/// プレイヤーが物を持っているかどうかを返す
	/// </summary>
	/// <returns></returns>
	public bool GetHasObject()
	{
		if (!canUseLeftHand || !canUseRightHand)
			return true;
		else
			return false;
	}
}