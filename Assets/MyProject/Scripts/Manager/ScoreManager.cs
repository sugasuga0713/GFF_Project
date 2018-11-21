//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
	#region 変数
	private int[] scores = { 0, 0 };
    #region パラメータ

    #endregion

    #region キャッシュ

    #endregion

    #endregion

    #region プロパティ

	public int[] Scores
	{
		set
		{
			this.scores = value;
		}
		get
		{
			return this.scores;
		}
	}

	#endregion

	protected override void Init()
	{
		base.Init();

	}

	public void AddScore(int playerNo,int addScore)
	{
		scores[playerNo] += addScore;
		//UIManager.Instantiate
	}
	public int GetScore(int playerNo)
	{
		return scores[playerNo];
	}
}