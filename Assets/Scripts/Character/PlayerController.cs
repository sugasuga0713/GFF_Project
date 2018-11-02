//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ
	
	[Header("プレイヤー番号")] [SerializeField] private int playerNo = 1; //プレイヤー番号　1～4
	[Header("耐久値")] [SerializeField] private int hp = 100;
	[Header("攻撃力")] [SerializeField] private int attackPower = 10;
	[Header("移動速度")] [SerializeField] private float moveSpeed = 10;
	[Header("自分の重量(kg)")] [SerializeField] private int myWeight = 300;
	[Header("総重量(kg)")] [SerializeField] private int grossWeight = 300;

	private Vector3 moveDir;

	#endregion

	#region キャッシュ
	private new Rigidbody rigidbody;
	private ArmedManager armedManager;
	#endregion

	#endregion

	#region プロパティ
	public int PlayerNo
	{
		get
		{
			return playerNo;
		}
		set
		{
			playerNo = value;
		}
	}
	public int Hp
	{
		get
		{
			return hp;
		}
		set
		{
			hp = value;
		}
	}
	public int AttackPower
	{
		get
		{
			return attackPower;
		}
		set
		{
			attackPower = value;
		}
	}
	public float MoveSpeed
	{
		get
		{
			return moveSpeed;
		}
		set
		{
			moveSpeed = value;
		}
	}
	public Vector3 MoveDir
	{
		set
		{
			moveDir.x = value.x;
			moveDir.y = 0;
			moveDir.z = value.y;
		}
	}
	public int GrossWeight
	{
		get
		{
			return grossWeight;
		}
		set
		{
			grossWeight = value;
		}
	}
    #endregion

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Initialize()
    {
        base.Initialize();
		rigidbody = GetComponent<Rigidbody>();
		armedManager = GetComponent<ArmedManager>();
    }

	/// <summary>
	/// 更新処理
	/// </summary>
	public override void UpdateMe()
	{
		if (armedManager.GetHasObject())
		{
			grossWeight = armedManager.GetGrossWeight();
		}
		else
		{
			grossWeight = myWeight;
		}
    }

    /// <summary>
    /// 固定更新処理
    /// </summary>
	public override void FixedUpdateMe()
	{
		Move();
	}

	/// <summary>
	/// 移動処理
	/// </summary>
	public void Move()
	{
		rigidbody.velocity = moveDir * moveSpeed * Time.deltaTime;
	}

	public void Action(bool left)
	{
		if (left)
		{
			if (armedManager.CanUseLeftHand)
			{
				PickUp(left);
			}
			else
			{
				Throw(left);
			}
		}
		else
		{
			if (armedManager.CanUseRightHand)
			{
				PickUp(!left);
			}
			else
			{
				Throw(!left);
			}
		}
	}

	/// <summary>
	/// 落ちているものを拾って装備する
	/// </summary>
	public void PickUp(bool left)
	{

	}

	/// <summary>
	/// 持っている物を投げる
	/// </summary>
	public void Throw(bool left)
	{

	}

}