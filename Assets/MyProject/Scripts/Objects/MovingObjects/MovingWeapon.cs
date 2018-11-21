//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWeapon : Weapon
{
	#region 変数

	#region パラメータ
	public MovingConfig movingConfig = null;
	private float energy;
	private bool canMove = false;
	private bool hasEnergy = true;
	#endregion

	#region キャッシュ
	[Header("プレイヤーのTransform")] [SerializeField] private Transform playerTransform = null;
	[Header("バーナーのゲームオブジェクト")] [SerializeField] private GameObject burner = null;
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
		energy = movingConfig.energy;
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
		if (canMove)
		{
			Move();
		}

	}

	/// <summary>
	/// 武器の使用
	/// </summary>
	public override void Action(PlayerController i_playerController)
	{
		base.Action(i_playerController);

		if (!hasEnergy) return;
		canMove = true;
		burner.SetActive(true);
	}

	public override void EndAction()
	{
		if (!hasEnergy) return;
		canMove = false;
		burner.SetActive(false);
	}

	protected virtual void Move()
	{
		if (!hasEnergy) return;

		energy -= Time.deltaTime;
		if(energy <= 0)	
		{
			energy = 0;
			hasEnergy = false;
			burner.SetActive(false);
		}
		if (myTransform.parent != null)
		{
			//playerTransform.Translate(myTransform.up * moveSpeed * Time.deltaTime);
			playerTransform.GetComponent<Rigidbody>().AddForce(myTransform.forward * movingConfig.moveForce * Time.deltaTime);
		}
		else
		{
			myTransform.Translate(movingConfig.moveDir * movingConfig.moveSpeed * Time.deltaTime);
		}
	}

}