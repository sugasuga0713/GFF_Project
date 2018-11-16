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
	[Header("時間")] [SerializeField] protected float lifeTime = 3.0f;
	[Header("移動方向")] [SerializeField] protected Vector3 moveDir = Vector3.zero;
	protected float lifeTimeCount;
	#endregion

	#region キャッシュ
	protected PlayerController playerController;
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
		//Move();
	}

	public virtual void Setting(Transform gunTransform,PlayerController pController)
	{
		playerController = pController;
		if (myTransform == null) myTransform = GetComponent<Transform>();
		lifeTimeCount = lifeTime;
		myTransform.position = gunTransform.position;
		myTransform.rotation = gunTransform.rotation;
		gameObject.SetActive(true);
	}

	public bool ActiveSelf()
	{
		return gameObject.activeSelf;
	}

	private void OnTriggerEnter(Collider other)
	{
		gameObject.SetActive(false);
		lifeTimeCount = lifeTime;
	}
}