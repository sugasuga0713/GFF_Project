//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
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

	public void ScoreDisplay(int playersNo)
	{

	}

	public void TimeDisplay(int remTime)
	{
		remTimeText.text = remTime.ToString("D3");
	}
}