//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ
	[Header("回転速度")] [SerializeField] private float rotateSpeed = 1.0f;
	[Header("追従のなめらかさ")] [SerializeField] private float smoothing = 5f;
	[Header("カメラとの距離")] [SerializeField] private float distance = 5;
	[Header("縦方向の回転上限")] [SerializeField] [Range(0, 90)] private float upperLimit = 45;
	[Header("縦方向の回転下限")] [SerializeField] [Range(-30, 0)] private float lowerLimit = -2;

	private Vector3 angle;
	private Vector3 offset;

	private Vector2 inputAngle = Vector2.zero;
	private bool subjectiveMode = false; //主観視点かどうか
	#endregion

	#region キャッシュ
	[SerializeField] private Transform playerTransform = null;
	[SerializeField] private Transform viewPoint = null;
	[SerializeField] private Transform myParent = null;

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
		offset = myTransform.position - playerTransform.position;

	}

	/// <summary>
	/// 固定更新処理
	/// </summary>
	public override void FixedUpdateMe()
	{
		myTransform.position = Vector3.Lerp(
		myTransform.position,
		myParent.position,
		Time.deltaTime * smoothing);

		playerTransform.Rotate(new Vector3(0, inputAngle.y, 0));
		viewPoint.Rotate(new Vector3(inputAngle.x,0,0));


		float angleX = inputAngle.x * rotateSpeed * Time.deltaTime + viewPoint.eulerAngles.x;
		if (angleX > 90)
		{
			angleX -= 360;
		}
		angleX = Mathf.Clamp(angleX, lowerLimit, upperLimit);

		viewPoint.SetEulerAngleX(angleX);
		myTransform.LookAt(playerTransform.position);

	}

	/// <summary>
	/// 回転角度入力
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	public void AngleInput(float x, float y)
	{
		angle.y += x * rotateSpeed;
		angle.x += y * rotateSpeed;
		angle.y = Mathf.Clamp(angle.y, lowerLimit, upperLimit);
		inputAngle.x = x;
		inputAngle.y = y;
	}
}