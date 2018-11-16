//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonMonoBehaviour<CharacterManager>
{
	#region 変数

	#region パラメータ

	#endregion

	#region キャッシュ
	[SerializeField] private Transform[] playerPos = null;
	[SerializeField] public PlayerController[] playerScripts = null;

	private int i;
	#endregion

	#endregion

	#region プロパティ

	#endregion

    public void CharacterSetUp()
	{
		for (i = 0; i < playerPos.Length; i++)
		{
			playerScripts[i].SetUp(playerPos[i].position);
		}
	}

	public Vector3 ReturnOpponentPosition(PlayerController pController)
	{
		if (pController == playerScripts[0])
			return playerPos[1].position;
		else
			return playerPos[0].position;

	}

}