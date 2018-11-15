//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
	#region 変数

	#region パラメータ
	public GunConfig gunConfig = null;
	private int remBullets; //残弾数
	#endregion

	#region キャッシュ
	[Header("発射位置")] public Transform shotPosition = null;
	[Header("弾の管理スクリプト")] public BulletManager bulletManager = null;
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
		remBullets = gunConfig.remainingBullets;
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
	/// 武器の使用
	/// </summary>
	public override void Action()
	{
		if (remBullets > 0)
		{
			Shot();
		}else
		{
			MisFire();
		}
	}

	protected void Shot()
	{
		BaseBullet bullet = bulletManager.GetBullet(gunConfig.bulletType);
		if (bullet == null) return;

		remBullets--;
		bullet.Setting(shotPosition);
	}

	protected void MisFire()
	{
		Debug.Log("弾がありません");
	}
}