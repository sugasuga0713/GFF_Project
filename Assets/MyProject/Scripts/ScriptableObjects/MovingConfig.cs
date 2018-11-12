//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MovingConfig : ScriptableObject
{
	#region 変数

	#region パラメータ
	[Header("移動速度")] public float moveSpeed = 10.0f;
	[Header("移動するときに加える力")] public float moveForce = 1000f;

	[Header("エネルギー量")] public float energy = 10.0f;
	[Header("移動方向")] public Vector3 moveDir = Vector3.zero;
	#endregion

	#region キャッシュ

	#endregion

	#endregion

	#region プロパティ

	#endregion

}