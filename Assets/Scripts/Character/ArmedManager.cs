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
	private bool leftHandHas = false; //左手に物を持っているか
	private bool rightHandHas = false; //右手に物を持っているか

	private BaseObject objectLeft; //左手で持っているオブジェクト
	private BaseObject objectRight; //右手で持っているオブジェクト

	#endregion

	#region キャッシュ
	[Header("左手で持つオブジェクトの位置")] [SerializeField] private Transform leftHandPoint = null;
	[Header("右手で持つオブジェクトの位置")] [SerializeField] private Transform rightHandPoint = null;
	#endregion

	#endregion

	#region プロパティ
	public bool LeftHandHas
	{
		get
		{
			return leftHandHas;
		}
	}
	public bool RightHandHas
	{
		get
		{
			return rightHandHas;
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

	public void PickUp(PlayerController.Hand hand, BaseObject obj)
	{
		if (hand == PlayerController.Hand.LEFT)
		{
			leftHandHas = true;
			objectLeft = obj;
			obj.myTransform.position = leftHandPoint.position;
			obj.myTransform.parent = leftHandPoint;
		}
		else
		{
			rightHandHas = true;
			objectRight = obj;
			obj.myTransform.position = rightHandPoint.position;
			obj.myTransform.parent = rightHandPoint;
		}
		obj.IsHaved = true;
		obj.GetComponent<Rigidbody>().isKinematic = true;
		
	}

	public void Throw(PlayerController.Hand hand)
	{
		if (hand == PlayerController.Hand.LEFT)
		{
			leftHandHas = false;
			objectLeft.IsHaved = false;
			objectLeft.myTransform.parent = null;
			objectLeft.GetComponent<Rigidbody>().isKinematic = false;
			objectLeft = null;
		}
		else
		{
			rightHandHas = false;
			objectRight.IsHaved = false;
			objectRight.myTransform.parent = null;
			objectRight.GetComponent<Rigidbody>().isKinematic = false;
			objectRight = null;
		}
	}

	public int GetGrossWeight(int playerWeight)
	{
		int weight = playerWeight;
		if (leftHandHas)
		{
			weight += objectLeft.MyWeight;
		}
		if(rightHandHas)
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
		if (leftHandHas || rightHandHas)
			return true;
		else
			return false;
	}
}