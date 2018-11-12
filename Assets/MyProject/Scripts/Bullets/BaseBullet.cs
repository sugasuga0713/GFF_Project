//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ
	[Header("移動速度")] [SerializeField] private float moveSpeed = 10.0f;
	[Header("時間")] [SerializeField] private float lifeTime = 3.0f;
	[Header("移動方向")] [SerializeField] private Vector3 moveDir = Vector3.zero;
	private float lifeTimeCount;
	#endregion

	#region キャッシュ

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
		lifeTimeCount -= Time.deltaTime;
		if(lifeTimeCount <= 0)
		{
			gameObject.SetActive(false);
			lifeTimeCount = lifeTime;
		}
    }

    /// <summary>
    /// 固定更新処理
    /// </summary>
	public override void FixedUpdateMe()
	{
		Move();
	}

	public virtual void Setting(Transform gunTransform)
	{
		if (myTransform == null) myTransform = GetComponent<Transform>();
		lifeTimeCount = lifeTime;
		myTransform.position = gunTransform.position;
		myTransform.rotation = gunTransform.rotation;
		gameObject.SetActive(true);
	}

	private void Move()
	{
		myTransform.Translate(moveDir * moveSpeed * Time.deltaTime);
	}

	public bool ActiveSelf()
	{
		return gameObject.activeSelf;
	}
}