//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseObject
{
	#region 変数
	public enum Hand
	{
		LEFT = 0, RIGHT = 1
	}
	#region パラメータ
	
	[Header("プレイヤー番号")] [SerializeField] private int playerNo = 1; //プレイヤー番号　1～4
	[Header("耐久値")] [SerializeField] private int hp = 100;
	[Header("移動速度")] [SerializeField] private float moveSpeed = 10;
	[Header("重量")] [SerializeField] private float weight = 1;
	[Header("総重量(kg)")] [SerializeField] private float grossWeight = 300;

	private Vector3 moveDir;

	#endregion

	#region キャッシュ
	private ArmedManager armedManager;
	public Transform playerModel;
	[Header("ObjectManagerをアタッチ")][SerializeField] private ObjectManager objectManager = null;
	[SerializeField] private Transform cameraTransform = null;
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

	public float GrossWeight
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

		armedManager = GetComponent<ArmedManager>();
		armedManager.SetUp(playerNo);
		//playerModel = myTransform.Find("model");
    }

	/// <summary>
	/// 更新処理
	/// </summary>
	public override void UpdateMe()
	{
		if (armedManager.GetHasObject())
		{
			armedManager.BrokenCheck();
			grossWeight = armedManager.GetGrossWeight(weight);
		}
		else
		{
			grossWeight = weight;
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
	/*	// カメラの方向から、X-Z平面の単位ベクトルを取得
		Vector3 cameraForward = Vector3.Scale(cameraTransform.up, new Vector3(1, 0, 1)).normalized;
		if (cameraTransform.eulerAngles.x > 90)
		{
			cameraForward *= -1;
		}
		// 方向キーの入力値とカメラの向きから、移動方向を決定
		Vector3 moveForward = cameraForward * moveDir.z + cameraTransform.right * moveDir.x;

		playerModel.LookAt(myTransform.position + moveForward.normalized);*/

		myTransform.Translate(moveDir * moveSpeed * Time.deltaTime);

		//rigidbody.velocity = moveDir * moveSpeed * Time.deltaTime;
	}

	public void Action1(Hand hand)
	{
		//左手ならhandNoに0、右手なら1が入る
		int handNo = (int)hand; 

		//左手（右手）にものを持っていないときは物を拾う処理、持っているときは物を捨てる処理を行う
		if (!armedManager.hasHand[handNo]) 
		{
			PickUp(hand);
		}
		else
		{
			ThrowAway(hand);
		}
	}

	public void Action2(Hand hand)
	{
		//左手ならhandNoに0、右手なら1が入る
		int handNo = (int)hand;

		//物を持っていないときはreturn
		if (!armedManager.hasHand[handNo]) return;

		//持っているもののスクリプトを参照し、アクション処理を行う
		armedManager.handWeapons[handNo].Action();
	}

	public void EndAction(Hand hand)
	{
		int handNo = (int)hand;

		if (!armedManager.hasHand[handNo]) return;

		armedManager.handWeapons[handNo].EndAction();
	}

	/// <summary>
	/// 落ちているものを拾って装備する
	/// </summary>
	public void PickUp(Hand hand)
	{
		Weapon obj = objectManager.GetObjectInRange(0,myTransform.position);

		if (obj == null) return;

		armedManager.PickUp(hand,obj);
	}

	/// <summary>
	/// 持っている物を投げる
	/// </summary>
	public void ThrowAway(Hand hand)
	{
		armedManager.ThrowAway(hand);
	}

	public void Damage(int damage)
	{
		hp -= damage;
		if(hp<= 0)
		{
			hp = 0;
		}
	}

	public void SetUp(Vector3 pos)
	{

	}

}