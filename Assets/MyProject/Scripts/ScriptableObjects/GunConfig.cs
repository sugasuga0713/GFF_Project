//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunConfig : ScriptableObject
{
	#region 変数

	#region パラメータ
	[Header("弾の種類")] public BulletManager.BulletType bulletType = BulletManager.BulletType.NONE;
	[Header("残弾数")] public int remainingBullets = 10; //残弾数
	
	#endregion

	#region キャッシュ

	#endregion

	#endregion

	#region プロパティ

	#endregion

}