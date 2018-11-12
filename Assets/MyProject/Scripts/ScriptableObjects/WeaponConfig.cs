//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponConfig : ScriptableObject
{
	#region 変数

	#region パラメータ
	[Header("名前")]  public new string name = "なまえ";
	[Header("耐久値")] public int hp = 100;
	[Header("攻撃力")] public int attack = 10;
	[Header("重量(t)")] public float weight = 1;
	[Header("装備角度")] public Vector3 serAngle;

    #endregion

    #region キャッシュ

    #endregion

    #endregion

    #region プロパティ

    #endregion

}