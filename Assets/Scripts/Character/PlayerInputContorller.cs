//作成者　　　：
//作成日　　　：
//機能　　　　：
//最終更新日　：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputContorller : ManagedUpdateBehaviour
{
	#region 変数

	private enum InputCommand
	{
		Horizontal,Vertical
	}

	#region パラメータ
	private bool isConnectedGamePad = false;
	#endregion

	#region キャッシュ
	private PlayerController playerController;
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
		playerController = GetComponent<PlayerController>();
		CheckGamePad();
	}

	/// <summary>
	/// 更新処理
	/// </summary>
	public override void UpdateMe()
	{
		if (isConnectedGamePad)
			GamePadInput();
		else
			KeyboardInput();
	}

	/// <summary>
	/// 固定更新処理
	/// </summary>
	public override void FixedUpdateMe()
	{

	}

	/// <summary>
	/// ゲームパッドが接続されているかの確認処理
	/// </summary>
	private void CheckGamePad()
	{
		var controllerNames = Input.GetJoystickNames();
		Debug.Log(controllerNames.Length);

		// ゲームパッドが接続されていないときは変数をfalse、接続されているときはtrueにする
		if (controllerNames.Length == 0)
		{
			isConnectedGamePad = false;
		}
		else
		{
			isConnectedGamePad = true;
		}
	}

	private void GamePadInput()
	{

	}

	private void KeyboardInput()
	{
		Vector2 inputDir = Vector2.zero;
		inputDir.x = Input.GetAxis(InputCommand.Horizontal.ToString());
		inputDir.y = Input.GetAxis(InputCommand.Vertical.ToString());
		playerController.MoveDir = inputDir;
	}

}