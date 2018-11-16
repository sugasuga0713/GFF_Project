//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallisticSupport
{
	public static void Ballistic(this Rigidbody rb, Vector3 shootPos, Vector3 targetPos,float height)
	{
		//撃つ高さを固定する
		float t1, t2;

		float g = Physics.gravity.y;

		//開始から最大高度までの時間を計算する
		float timeSquare = 2 * (shootPos.y - height) / g;
		if (timeSquare <= 0.0f)
			t1 = 0.0f;
		else
			t1 = Mathf.Sqrt(timeSquare);
		//最大高度から終了までの時間を計算する
		timeSquare = 2 * (targetPos.y - height) / g;
		if (timeSquare <= 0.0f)
			t2 = 0.0f;
		else
			t2 = Mathf.Sqrt(timeSquare);

		if (t1 <= 0.0f && t2 <= 0.0f)
		{
			// その位置に着地させることは不可能のようだ！
			Debug.LogWarning("!!");
			return;
		}

		float time = t1 + t2; //時間の計算が終了

		//時間から角度を計算
		Vector2 vec;

		//時間からベクトルXYを計算
		// 瞬間移動はしない
		if (time <= 0.0f)
			vec = Vector2.zero;
		else
		{
			// xz平面の距離を計算。
			Vector2 startPos = new Vector2(shootPos.x, shootPos.z);
			Vector2 endPos = new Vector2(targetPos.x, targetPos.z);
			float distance = Vector2.Distance(endPos, startPos);

			vec = new Vector2(distance / time, (targetPos.y - shootPos.y) / time + (-g * time) / 2);
		}
		float angle = Mathf.Atan2(vec.y,vec.x) * Mathf.Rad2Deg;

		//
		float speedVec = Mathf.Sqrt(vec.x*vec.x + vec.y*vec.y);
		if (speedVec <= 0.0f)
			speedVec = 0.0f;
		Mathf.Sqrt(speedVec);

		//
		Vector3 startPos2 = shootPos;
		Vector3 endPos2 = targetPos;
		startPos2.y = 0.0f;
		endPos2.y = 0.0f;

		Vector3 dir = (endPos2 - startPos2).normalized;
		Quaternion yawRot = Quaternion.FromToRotation(Vector3.right, dir);
		Vector3 vec2 = speedVec * Vector3.right;

		vec2 = yawRot * Quaternion.AngleAxis(angle, Vector3.forward) * vec2;

		Vector3 force = vec2 * rb.mass;
		rb.velocity = Vector3.zero;
		rb.AddForce(force, ForceMode.Impulse);
	}

	private static void Hoge()
	{

	}
}