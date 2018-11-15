//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodySupport : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ
	[Header("飛ばす角度")] [SerializeField] private float angle = 60;
	private Vector3 shootPosition;
	private Vector3 targetPosition;
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
    
    }

    /// <summary>
    /// 固定更新処理
    /// </summary>
	public override void FixedUpdateMe()
	{

	}

	public Vector3 Shoot(Vector3 i_shootPosition,Vector3 i_targetPosition)
	{
		shootPosition = i_shootPosition;
		targetPosition = i_targetPosition;
		return ShootFixedAngle();
	}

	private Vector3 ShootFixedAngle()
	{
		float speedVec = ComputeVectorFromAngle(); //角度からベクトルを計算し、speedVecへ格納する
		if (speedVec <= 0.0f)
		{
			// 指定位置に着地は不可能
			Debug.LogWarning("!!");
			return Vector3.zero;
		}

		return ConvertVectorToVector3(speedVec);
	}

	//角度からベクトルを計算する
	private float ComputeVectorFromAngle()
	{
		// xz平面の距離を計算。
		Vector2 startPos = new Vector2(shootPosition.x, shootPosition.z);
		Vector2 targetPos = new Vector2(targetPosition.x, targetPosition.z);
		float distance = Vector2.Distance(targetPos, startPos);

		float x = distance;
		float g = Physics.gravity.y;
		float y0 = shootPosition.y;
		float y = targetPosition.y;

		// Mathf.Cos()、Mathf.Tan()に渡す値の単位はラジアン。角度のまま渡してはいけない
		float rad = angle * Mathf.Deg2Rad;

		float cos = Mathf.Cos(rad);
		float tan = Mathf.Tan(rad);

		float v0Square = g * x * x / (2 * cos * cos * (y - y0 - x * tan));

		// 負数を平方根計算すると虚数になる
		// 虚数はfloatでは表現できない
		// その場合、これ以上の計算は打ち切る
		if (v0Square <= 0.0f)
		{
			return 0.0f;
		}

		float v0 = Mathf.Sqrt(v0Square);
		return v0;
	}

	//ベクトルをVector3に変換する
	private Vector3 ConvertVectorToVector3(float i_v0)
	{
		Vector3 startPos = shootPosition;
		Vector3 targetPos = targetPosition;
		startPos.y = 0.0f;
		targetPos.y = 0.0f;

		Vector3 dir = (targetPos - startPos).normalized;
		Quaternion yawRot = Quaternion.FromToRotation(Vector3.right, dir);
		Vector3 vec = i_v0 * Vector3.right;

		vec = yawRot * Quaternion.AngleAxis(angle, Vector3.forward) * vec;

		return vec;
	}

}