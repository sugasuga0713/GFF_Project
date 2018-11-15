//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using UnityEngine;

public class Weapon : BaseObject
{
    #region 変数

    public enum WeaponType
	{
		NONE,MELEE,GUN,MOVING,TRAP
	}

	#region パラメータ

	private int hp;
	private bool isHaved = false; //プレイヤーに持たれている
	private bool isBroken = false; //壊れているかどうか

	public WeaponConfig weaponConfig;

	#endregion

	#region キャッシュ
	private PlayerController playerController;
	#endregion

	#region プロパティ
	public int Hp
	{
		get
		{
			return hp;
		}
		private set
		{
			hp = value;
		}
	}

	public bool IsHaved
	{
		get
		{
			return isHaved;
		}
		set
		{
			isHaved = value;
		}
	}

	public bool IsBroken
	{
		get
		{
			return isBroken;
		}

		set
		{
			isBroken = value;
		}
	}

	#endregion
	#endregion

	/// <summary>
	/// アイテムを拾ったときの処理
	/// </summary>
	public virtual void Setting(Transform shotTransform)
	{
		gameObject.layer = 9; //
		myTransform.position = shotTransform.position;
		myTransform.parent = shotTransform;
		IsHaved = true;
		rigidbody.isKinematic = true;

		myTransform.rotation = shotTransform.parent.rotation;
		myTransform.eulerAngles = (weaponConfig.setAngle + myTransform.eulerAngles);
	}

	/// <summary>
	/// アイテムを捨てたときの処理
	/// </summary>
	public virtual void UnSetting()
	{
		gameObject.layer = 8; //
		IsHaved = false;
		myTransform.parent = null;
		rigidbody.isKinematic = false;
	}

	/// <summary>
	/// 武器の使用
	/// </summary>
	public virtual void Action(PlayerController i_playerController)
	{
		playerController = i_playerController;
	}

	/// <summary>
	/// 
	/// </summary>
	public virtual void EndAction()
	{

	}

}