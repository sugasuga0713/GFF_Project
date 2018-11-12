//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ

	#endregion

	#region キャッシュ
	[Header("残り時間")] [SerializeField] private Text remTimeText = null;
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

	public void TimeDisplay(int remTime)
	{
		remTimeText.text = remTime.ToString("D3");
	}
}