//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ

	#endregion

	#region キャッシュ
	[SerializeField] private Text weightText = null;
	[SerializeField] private Text leftHandText = null;
	[SerializeField] private Text rightHandText = null;

	[SerializeField] private PlayerController playerController = null;
	[SerializeField] private ArmedManager armedManager = null;
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
		ShowText();
    }

    /// <summary>
    /// 固定更新処理
    /// </summary>
	public override void FixedUpdateMe()
	{

	}

	private void ShowText()
	{
		weightText.text = "総重量 : " + playerController.GrossWeight.ToString() + "t";
		if (armedManager.hasHand[0])
		{
			leftHandText.text = "左手 : " + armedManager.handWeapons[0].weaponConfig.name.ToString();
		}
		else
		{
			leftHandText.text = "左手 : " + "なし";
		}
		if (armedManager.hasHand[1])
		{
			rightHandText.text = "右手 : " + armedManager.handWeapons[1].weaponConfig.name.ToString();
		}
		else
		{
			rightHandText.text = "右手 : " + "なし";

		}
	}
}