//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : SingletonMonoBehaviour<MainManager>
{
	#region 変数

	#region パラメータ
	private int players = 2; //プレイ人数
	private bool gameEnd = false;
	#endregion

	#region キャッシュ
	[SerializeField] private CharacterManager characterManager = null;
	[SerializeField] private TimeManager timeManager = null;
	[SerializeField] private UIManager uiManager= null;
	#endregion

	#endregion

	#region プロパティ

	#endregion

	/// <summary>
	/// 初期化処理
	/// </summary>
	protected override void Init()
    {
        base.Initialize();
		//characterManager.CharacterSetUp();
    }

	/// <summary>
	/// 
	/// </summary>
	public override void UpdateMe()
	{
		if (!timeManager.UpdateTime())
			gameEnd = true;

		uiManager.TimeDisplay(timeManager.RemTime);
	}

}