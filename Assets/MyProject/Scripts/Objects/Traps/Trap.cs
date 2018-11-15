//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Weapon
{
	#region 変数

	#region パラメータ
	public TrapConfig trapConfig = null;
	[SerializeField] protected float remainingTime;
	protected bool isBuried = false; //埋まっているかどうか
	protected bool inAction = false; //埋められている途中かどうか

	#endregion

	#region キャッシュ
	[Header("生成オブジェクト")] [SerializeField] private GameObject prefab = null;
	[SerializeField] private Transform[] players = { null, null };
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
		remainingTime = trapConfig.preparationTime;
		prefab = myTransform.Find("effect").gameObject;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public override void UpdateMe()
    {
		if(inAction)
		{
			remainingTime -= Time.deltaTime;
			if(remainingTime <= 0)
			{
				Bury();
			}
		}
    }

    /// <summary>
    /// 固定更新処理
    /// </summary>
	public override void FixedUpdateMe()
	{
		if (isBuried)
		{
			CheckDistance();
		}
	}

	protected void Bury()
	{
		remainingTime = 0;
		inAction = false;
		isBuried = true;
		IsBroken = true;

	}

	/// <summary>
	/// 武器の使用
	/// </summary>
	public override void Action(PlayerController i_playerController)
	{
		base.Action(i_playerController);
		inAction = true;
	}

	public override void EndAction()
	{

	}

	protected void CheckDistance()
	{
		for (i = 0; i < players.Length; i++)
		{
			if (players[i] == null) return;

			float distance = Vector3.Distance(myTransform.position, players[i].position);
			if (distance <= trapConfig.harmRange)
			{
				EffectTriggered();
			}
		}
	}

	protected void EffectTriggered()
	{
		prefab.SetActive(true);
	}
}