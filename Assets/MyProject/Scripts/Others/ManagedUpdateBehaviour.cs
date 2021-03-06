﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagedUpdateBehaviour : MonoBehaviour
{
	[System.NonSerialized] public bool set = false;

	[System.NonSerialized] public Transform myTransform;

	protected virtual void Awake()
	{
		if (set)
			return;

		myTransform = GetComponent<Transform>();
		UpdateManager.Instance.Add(this); //このスクリプトをUpdateManagerの配列に加える
		Initialize();
		set = true;
	}

	protected virtual void Initialize() //Awakeの代わりの処理を書く
	{

	}

	public virtual void UpdateMe() //Updateの代わりの処理を書く
	{

	}

	public virtual void FixedUpdateMe() //FixedUpdateの代わりの処理を書く
	{

	}

}
