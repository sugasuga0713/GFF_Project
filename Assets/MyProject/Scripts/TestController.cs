using UnityEngine;

public class TestController : MonoBehaviour
{
	private Vector3 m_shootPoint;
	private Transform m_target = null;
	private Rigidbody m_rigidbody;

	//[Header("射出角度")] [SerializeField] [Range(0, 90)] private float angle = 80;
	[Header("最大高度")] [SerializeField] [Range(0, 10)] private float height = 30;

	public void Shoot(Vector3 i_targetPosition,Vector3 i_shootPosition,Rigidbody rigidbody)
	{
		m_rigidbody = rigidbody;
		m_shootPoint = i_shootPosition;
		ShootFixedHeight(i_targetPosition, height);
	}

	private void ShootFixedHeight(Vector3 i_targetPosition, float i_height)
	{
		float t1 = CalculateTimeFromStartToMaxHeight(i_targetPosition, i_height);
		float t2 = CalculateTimeFromMaxHeightToEnd(i_targetPosition, i_height);

		if (t1 <= 0.0f && t2 <= 0.0f)
		{
			// その位置に着地させることは不可能のようだ！
			Debug.LogWarning("!!");
			return;
		}


		float time = t1 + t2;

		ShootFixedTime(i_targetPosition, time);
	}

	private float CalculateTimeFromStartToMaxHeight(Vector3 i_targetPosition, float i_height)
	{
		float g = Physics.gravity.y;
		float y0 = m_shootPoint.y;

		float timeSquare = 2 * (y0 - i_height) / g;
		if (timeSquare <= 0.0f)
		{
			return 0.0f;
		}

		float time = Mathf.Sqrt(timeSquare);
		return time;
	}

	private float CalculateTimeFromMaxHeightToEnd(Vector3 i_targetPosition, float i_height)
	{
		float g = Physics.gravity.y;
		float y = i_targetPosition.y;

		float timeSquare = 2 * (y - i_height) / g;
		if (timeSquare <= 0.0f)
		{
			return 0.0f;
		}

		float time = Mathf.Sqrt(timeSquare);
		return time;
	}

	private void ShootFixedTime(Vector3 i_targetPosition, float i_time)
	{
		float speedVec = ComputeVectorFromTime(i_targetPosition, i_time);
		float angle = ComputeAngleFromTime(i_targetPosition, i_time);

		if (speedVec <= 0.0f)
		{
			// その位置に着地させることは不可能のようだ！
			Debug.LogWarning("!!");
			return;
		}

		Vector3 vec = ConvertVectorToVector3(speedVec, angle, i_targetPosition);
		InstantiateShootObject(vec);
	}

	private float ComputeVectorFromTime(Vector3 i_targetPosition, float i_time)
	{
		Vector2 vec = ComputeVectorXYFromTime(i_targetPosition, i_time);

		float v_x = vec.x;
		float v_y = vec.y;

		float v0Square = v_x * v_x + v_y * v_y;
		// 負数を平方根計算すると虚数になってしまう。
		// 虚数はfloatでは表現できない。
		// こういう場合はこれ以上の計算は打ち切ろう。
		if (v0Square <= 0.0f)
		{
			return 0.0f;
		}

		float v0 = Mathf.Sqrt(v0Square);

		return v0;
	}

	private float ComputeAngleFromTime(Vector3 i_targetPosition, float i_time)
	{
		Vector2 vec = ComputeVectorXYFromTime(i_targetPosition, i_time);

		float v_x = vec.x;
		float v_y = vec.y;

		float rad = Mathf.Atan2(v_y, v_x);
		float angle = rad * Mathf.Rad2Deg;

		return angle;
	}

	private Vector2 ComputeVectorXYFromTime(Vector3 i_targetPosition, float i_time)
	{
		// 瞬間移動はちょっと……。
		if (i_time <= 0.0f)
		{
			return Vector2.zero;
		}


		// xz平面の距離を計算。
		Vector2 startPos = new Vector2(m_shootPoint.x, m_shootPoint.z);
		Vector2 targetPos = new Vector2(i_targetPosition.x, i_targetPosition.z);
		float distance = Vector2.Distance(targetPos, startPos);

		float x = distance;
		// な、なぜ重力を反転せねばならないのだ...
		float g = -Physics.gravity.y;
		float y0 = m_shootPoint.y;
		float y = i_targetPosition.y;
		float t = i_time;

		float v_x = x / t;
		float v_y = (y - y0) / t + (g * t) / 2;

		return new Vector2(v_x, v_y);
	}

	private Vector3 ConvertVectorToVector3(float i_v0, float i_angle, Vector3 i_targetPosition)
	{
		Vector3 startPos = m_shootPoint;
		Vector3 targetPos = i_targetPosition;
		startPos.y = 0.0f;
		targetPos.y = 0.0f;

		Vector3 dir = (targetPos - startPos).normalized;
		Quaternion yawRot = Quaternion.FromToRotation(Vector3.right, dir);
		Vector3 vec = i_v0 * Vector3.right;

		vec = yawRot * Quaternion.AngleAxis(i_angle, Vector3.forward) * vec;

		return vec;
	}

	private void InstantiateShootObject(Vector3 i_shootVector)
	{
		/*if (m_shootObject == null)
		{
			throw new System.NullReferenceException("m_shootObject");
		}

		if (m_shootPoint == null)
		{
			throw new System.NullReferenceException("m_shootPoint");
		}

		var obj = Instantiate<GameObject>(m_shootObject, m_shootPoint.position, Quaternion.identity);
		var rigidbody = obj.AddComponent<Rigidbody>();
		*/
		// 速さベクトルのままAddForce()を渡してはいけないぞ。力(速さ×重さ)に変換するんだ
		Vector3 force = i_shootVector * m_rigidbody.mass;

		m_rigidbody.AddForce(force, ForceMode.Impulse);
	}

} // class TestController