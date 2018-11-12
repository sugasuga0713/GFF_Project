using System.Collections;
using UnityEngine;

public static class ExtensionMethods
{
	public static void ResetTransformation(this Transform trans)
	{
		trans.position = Vector3.zero;
		trans.rotation = Quaternion.identity;
		trans.localScale = new Vector3(1, 1, 1);
	}

	public static Vector2 GetPosition2D(this Transform trans)
	{
		return trans.position;
	}

	public static void LookAt2D(this Transform trans, Vector2 targetPosition)
	{
		var vec = ((Vector3)targetPosition - trans.localPosition).normalized;
		var angle = (Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg) - 90.0f;
		trans.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
	}

	public static float GetLookAtRotate(this Transform trans, Vector2 tartgetPosition)
	{
		float radian = Mathf.Atan2(tartgetPosition.y - trans.GetPosition2D().y, tartgetPosition.x - trans.GetPosition2D().x);
		//radianをdegreeに変換
		float degree = (radian-90) * 180 / Mathf.PI;
		return degree;
	}

	public static float GetLookAtRotate3D(this Transform trans,Vector3 tartgetPosition)
	{
		float radian = Mathf.Atan2(tartgetPosition.z - trans.position.z, tartgetPosition.x - trans.position.x);
		//radianをdegreeに変換
		float degree = (radian - 90) * 180 / Mathf.PI;
		return degree;
	}

	public static void SetPosition(this Transform trans ,Vector3 pos)
	{
		trans.position = pos;
	}

	public static void SetPosition(this Transform trans, Vector2 pos)
	{
		trans.SetPosition(pos.x, pos.y);
	}

	public static void SetPosition(this Transform trans, float x, float y)
	{
		trans.localPosition = new Vector2(x, y);
	}

	public static void SetPositionX(this Transform trans, float x)
	{
		trans.localPosition = new Vector2(x, trans.localPosition.y);
	}

	public static void SetPositionY(this Transform trans, float y)
	{
		trans.localPosition = new Vector2(trans.localPosition.x, y);
	}

	public static void SetVelocityX(this Rigidbody2D rb, float x)
	{
		rb.velocity = new Vector2(x, rb.velocity.y);
	}

	public static void SetVelocityY(this Rigidbody2D rb, float y)
	{
		rb.velocity = new Vector2(rb.velocity.x, y);
	}

	public static void SetRotation(this Transform trans, float angle)
	{
		trans.eulerAngles = new Vector3(trans.eulerAngles.x,trans.eulerAngles.y,angle);
	}

	public static void Rotate2D(this Transform trans, float value)
	{
		trans.SetRotation(trans.eulerAngles.z + value);
	}

	public static void Rotate3D(this Transform trans, float value)
	{
		trans.Rotate(new Vector3(0,value,0));
	}

	/// <summary>
	///	アフィン変換を行い、ベクトル(Vector2型)を返すプログラム
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="theta">θ 角度</param>
	public static Vector2 AffineTransformation(float x,float y,float theta)
	{
		return new Vector2(x * Mathf.Cos(theta) - y * Mathf.Sin(theta), x * Mathf.Sin(theta) + y * Mathf.Cos(theta));
	}

	public static Vector2 GetFrontPosition(this Transform trans,float distance)
	{
		float radian = trans.eulerAngles.z * Mathf.PI / 180;
		Vector2 pos = trans.GetPosition2D();
		pos.x -= Mathf.Sin(radian) * distance;
		pos.y += Mathf.Cos(radian) * distance;
		return pos;
	}

}
