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

	#region パラメータ
	private bool isConnectedGamePad = false;

	private bool pushActR = false;
	private bool pushActL = false;
	#endregion

	#region キャッシュ
	[SerializeField] private PlayerCameraController cameraController = null;
	[SerializeField] private Transform cameraPosTrans = null;
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
		//移動の入力 左スティック
		Vector2 inputDir = Vector2.zero;
		inputDir.x = Input.GetAxis(CommandName.Horizontal);
		inputDir.y = Input.GetAxis(CommandName.Vertical);
		playerController.MoveDir = inputDir;
		//

		//カメラの回転入力 右スティック
		cameraController.AngleInput(Input.GetAxis(CommandName.R_Horizontal), Input.GetAxis(CommandName.R_Vertical));

		if(Input.GetButtonDown(CommandName.CameraMode))
		{
			//cameraController.SetCameraMode(cameraPosTrans,playerController.playerModel.eulerAngles,!cameraController.GetCameraMode());
		}

		//アクション1の入力 L,Rボタン
		if (Input.GetButtonDown(CommandName.L_PickUp))
		{
			playerController.Action1(PlayerController.Hand.LEFT);
		}
		if (Input.GetButtonDown(CommandName.R_PickUp))
		{
			playerController.Action1(PlayerController.Hand.RIGHT);
		}

		//アクション2の入力 LT,RTボタン
		if (Input.GetAxisRaw(CommandName.L_Action) >0)
		{
			if (!pushActL)
			{
				pushActL = true;
				playerController.Action2(PlayerController.Hand.LEFT);
			}
		}
		else
		{
			if (pushActL)
			{
				pushActL = false;
				playerController.EndAction(PlayerController.Hand.LEFT);
			}
			
		}
		if (Input.GetAxisRaw(CommandName.R_Action) > 0)
		{
			if (!pushActR)
			{
				pushActR = true;
				playerController.Action2(PlayerController.Hand.RIGHT);
			}
		}
		else
		{
			if (pushActR)
			{
				pushActR = false;
				playerController.EndAction(PlayerController.Hand.RIGHT);
			}

		}

	}

	private void KeyboardInput()
	{
		Vector2 inputDir = Vector2.zero;
		inputDir.x = Input.GetAxis(CommandName.Horizontal);
		inputDir.y = Input.GetAxis(CommandName.Vertical);
		playerController.MoveDir = inputDir;

		cameraController.AngleInput(Input.GetAxis(CommandName.R_Horizontal),Input.GetAxis(CommandName.R_Vertical));

		if (Input.GetKeyDown(KeyCode.O))
		{
			playerController.Action1(PlayerController.Hand.LEFT);
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			playerController.Action1(PlayerController.Hand.RIGHT);
		}
		if(Input.GetKeyDown(KeyCode.K))
		{
			playerController.Action2(PlayerController.Hand.LEFT);
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			playerController.Action2(PlayerController.Hand.RIGHT);
		}
	}

}