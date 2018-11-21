//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardCannonBullets : BaseBullet
{
	#region 変数

	#region パラメータ
	#endregion

	#region キャッシュ
	private new Rigidbody rigidbody;

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
		rigidbody = GetComponent<Rigidbody>();
    }
	public override void Setting(Transform gunTransform, PlayerController pController)
	{
		base.Setting(gunTransform, pController);
		myTransform.eulerAngles = Vector3.zero;
		rigidbody.Ballistic(myTransform.position, CharacterManager.Instance.ReturnOpponentPosition(playerController), 30);
	}

	private void OnTriggerEnter(Collider other)
	{
		CreateManager.Instance.CreateObject("explosion",myTransform.position,3.0f);
		gameObject.SetActive(false);
	}

}