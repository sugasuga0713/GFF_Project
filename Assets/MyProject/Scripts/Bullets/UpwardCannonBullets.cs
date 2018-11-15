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
	[SerializeField] RigidBodySupport bodySupport = null;
	[SerializeField] private Transform targetTransform = null;
	[Header("射出角度")] [SerializeField] [Range(0, 90)] private float angle = 80;
	[Header("最大高度")] [SerializeField] [Range(0,10)]  private float height= 10;

	[SerializeField] private TestController test = null;
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
	public override void Setting(Transform gunTransform)
	{
		{
			if (myTransform == null) myTransform = GetComponent<Transform>();

			lifeTimeCount = lifeTime;
			myTransform.position = gunTransform.position;
			gameObject.SetActive(true);
			rigidbody.velocity = Vector3.zero;
			test.Shoot(new Vector3(0,0,0), myTransform.position,rigidbody);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		CreateManager.Instance.CreateObject("explosion",myTransform.position,3.0f);
		gameObject.SetActive(false);
	}

}