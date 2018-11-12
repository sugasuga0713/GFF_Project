//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : ManagedUpdateBehaviour
{
	#region 変数

	#region パラメータ
	[Header("回転速度")] [SerializeField] private float rotateSpeed = 1.0f;
	[Header("追従のなめらかさ")] [SerializeField] private float smoothing = 5f;
	private Vector3 angle;
	private Vector3 offset;
	[Header("カメラとの近さ")] [SerializeField] private float radius = 5;

	private Vector2 inputAngle = Vector2.zero;
	private bool subjectiveMode = false; //主観視点かどうか

	#endregion

	#region キャッシュ
	[SerializeField] private Transform playerTransform = null;
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
		offset.z = 0;
		///radius = Vector3.Distance(playerTransform.position, myTransform.position);
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
		if (subjectiveMode) //主観視点のとき
		{
			Subjective();
		}
		else
		{
			Objective();
		}
	}

	private void SubjectiveRotate()
	{
		//myTransform.Rotate(new Vector3(inputAngle.x,inputAngle.y, 0));
		myTransform.eulerAngles += new Vector3(inputAngle.x,inputAngle.y,0);
	}

	private void ObjectiveRotate()
	{
		Vector3 rotDir = Quaternion.Euler(angle.y, angle.x, 0f) * Vector3.back;
		myTransform.position = playerTransform.position + radius * rotDir + offset;

		myTransform.LookAt(playerTransform.position);
	}

	public void AngleInput(float x, float y)
	{
		angle.y += x * rotateSpeed;
		angle.x += y * rotateSpeed;
		inputAngle.x = x;
		inputAngle.y = y;
	}

	public void SetCameraMode(Transform setTrans,Vector3 angle,bool mode)
	{
		if(mode)
		{
			SetSubjective(setTrans,angle);
		}
		else
		{
			ResetSubjective();
		}
	}
	public bool GetCameraMode()
	{
		return subjectiveMode;
	}

	private void SetSubjective(Transform setTrans,Vector3 ang)
	{
		myTransform.position = setTrans.position;
		myTransform.eulerAngles = ang;
		myTransform.parent = setTrans;
		subjectiveMode = true;
	}
	private void ResetSubjective()
	{
		myTransform.parent = null;
		subjectiveMode = false;
	}

	private void Subjective()
	{
		myTransform.position = playerTransform.position + offset;
		SubjectiveRotate();
	}

	private void Objective()
	{
		myTransform.position = Vector3.Lerp(
		   myTransform.position,
		   playerTransform.position + offset,
		   Time.deltaTime * smoothing
	   );

		ObjectiveRotate();
	}
}