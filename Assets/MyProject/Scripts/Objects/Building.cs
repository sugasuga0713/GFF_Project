﻿//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ

	#endregion

	#region キャッシュ
	[SerializeField] private Transform childTrans = null;
	[SerializeField] private Rigidbody childRbs = null;
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
}