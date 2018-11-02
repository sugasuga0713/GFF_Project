//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ
	[Header("名前")] [SerializeField] private string objName = "";
	[Header("耐久値")] [SerializeField] private int hp = 100;
	[Header("攻撃力")] [SerializeField] private int attackPower = 10;
	[Header("自分の重量(kg)")] [SerializeField] private int myWeight = 300;

	private bool isHaved = false; //プレイヤーに持たれている
	#endregion

	#region キャッシュ

	#endregion

	#endregion

	#region プロパティ
	public string Name
	{
		get
		{
			return objName;
		}
	}
	public int Hp
	{
		get
		{
			return hp;
		}
	}

	public int AttackPower
	{
		get
		{
			return attackPower;
		}
	}
	public int MyWeight
	{
		get
		{
			return myWeight;
		}
	}

	public bool IsHaved
	{
		get
		{
			return isHaved;
		}
		set
		{
			isHaved = value;
		}
	}
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
}