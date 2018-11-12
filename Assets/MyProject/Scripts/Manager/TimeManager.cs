//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ
	[Header("対戦時間")] [SerializeField] private int playTime = 180;
	private float timer = 0;
	private int remTime = 0; //残り時間

    #endregion

    #region キャッシュ

    #endregion

    #endregion

    #region プロパティ
	public int RemTime
	{
		get
		{
			return remTime;
		}
	}
    #endregion

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Initialize()
    {
        base.Initialize();
		remTime = playTime;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public bool UpdateTime()
    {

		timer += Time.deltaTime;
		if(timer >= 1)
		{
			timer = 0;
			remTime--;
		}

		if (remTime > 0)
			return true;
		else
			return false;
    }

}