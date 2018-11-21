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

	private int playerNo;
	//手に武器を持っているかどうか
	/*[System.NonSerialized]*/ public bool[] hasHand = { false, false };

	//持っている武器
	[System.NonSerialized] public Weapon[] handWeapons = { null, null };

	#endregion

	#region キャッシュ
	[Header("持つオブジェクトの位置")] [SerializeField] private Transform[] handPoint = { null, null };

	private int i; 

	#endregion

	#endregion

	#region プロパティ

	#endregion

	public void SetUp(int no)
	{
		playerNo = no;
	}

	public void PickUp(PlayerController.Hand hand, Weapon obj)
	{
		int handNo = (int)hand;
		hasHand[handNo] = true;
		handWeapons[handNo] = obj;
		obj.Setting(handPoint[handNo]);
	}

	public void ThrowAway(PlayerController.Hand hand)
	{
		int handNo = (int)hand;
		hasHand[handNo] = false;
		handWeapons[handNo].UnSetting();
		handWeapons[handNo] = null;
	}

	public float GetGrossWeight(float playerWeight)
	{
		float weight = playerWeight;
		if (hasHand[0])
		{
			weight += handWeapons[0].weaponConfig.weight;
		}
		if(hasHand[1])
		{
			weight += handWeapons[1].weaponConfig.weight;
		}

		return weight;
	}

	public void BrokenCheck()
	{
		for(i = 0;i<2;i++)
		{
			if(hasHand[i])
			{
				if(handWeapons[i].IsBroken)
				{
					ThrowAway((PlayerController.Hand)i);
				}
			}
		}
	}

	/// <summary>
	/// プレイヤーが物を持っているかどうかを返す
	/// </summary>
	/// <returns></returns>
	public bool GetHasObject()
	{
		if (hasHand[0] || hasHand[1])
			return true;
		else
			return false;
	}
}