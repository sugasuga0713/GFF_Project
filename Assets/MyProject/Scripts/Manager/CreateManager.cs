using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateManager : SingletonMonoBehaviour<CreateManager> {

	[System.Serializable] private class CreateSetting
	{
		public string key = null;
		public GameObject obj = null;
	}

	[System.Serializable] private class ObjectElement
	{
		public GameObject obj = null;
		public int number = 0;
	}

	[System.Serializable] private class ObjectData
	{
		public List<GameObject> objList = new List<GameObject>();
		public Transform parent = null;

		public void ParentSet(string keyName, Transform myTransform)
		{
			GameObject obj = new GameObject(keyName);
			parent = obj.transform;
			obj.transform.parent = myTransform;
		}
		public void AddObject(GameObject obj)
		{
			objList.Add(obj);
			obj.transform.parent = parent;
			obj.SetActive(false);
		}

		public void AddObject(GameObject obj,Vector3 pos)
		{
			objList.Add(obj);
			obj.transform.parent = parent;
			obj.transform.position = pos;
		}
	}

	[SerializeField] private CreateSetting[] setting = null;
	private List<ObjectElement> objectElement = new List<ObjectElement>();

	private Dictionary<string, ObjectElement> dictuinary = new Dictionary<string, ObjectElement>();

	private List<ObjectData> objDataList = new List<ObjectData>();

	private ObjectElement nullObj;

	int i;

	protected override void Init()
	{
		int length = setting.Length;
		//Array.Resize(ref objectElement,length); //objectElementの要素数をsettingリストのサイズと同じにする
		for (i = 0; i < length; i++)
		{
			objectElement.Add(new ObjectElement());
			objectElement[i].obj = setting[i].obj;
			objectElement[i].number = i; //objectElementのnumberをループ回数に
			dictuinary.Add(setting[i].key,objectElement[i]); //settingにkeyと更新したobjectElementをDictionaryに追加
		}

		for(i = 0; i < length; i++)
		{
			ObjectData data = new ObjectData();
			data.ParentSet(setting[i].key,transform);
			data.AddObject(Instantiate(objectElement[i].obj));
			objDataList.Add(data);
		}
	}

	public void CreateObject(string key, Vector3 pos, float lifeTime)
	{
		if (dictuinary.TryGetValue(key, out nullObj))
		{
			int count = objDataList[nullObj.number].objList.Count;
			for (i = 0; i < count; i++)
			{
				if (!objDataList[nullObj.number].objList[i].activeSelf) //非表示のオブジェクトがあったとき
				{
					GameObject createObj = objDataList[nullObj.number].objList[i];
					createObj.SetActive(true);
					createObj.transform.position = pos;
					StartCoroutine(DestroyObject(createObj, lifeTime));
					return;
				}

			}
			//非表示のオブジェクトがなかった時
			GameObject instance = Instantiate(nullObj.obj) as GameObject;
			objDataList[nullObj.number].AddObject(instance, pos);
			StartCoroutine(DestroyObject(instance, lifeTime));

			return;
		}
		else
		{
			// Debug.Log(effectKey + "に対応したEffectはありません");
			return;
		}

	}
	/*
	public GameObject GetCreateObject(string key, Vector3 pos)
	{
		if (dictuinary.TryGetValue(key, out nullObj))
		{
			if (gameObjectsList.Count != 0)
			{
				Debug.Log(gameObjectsList.Count);
				for (i = 0; i < gameObjectsList.Count; i++)
				{
					Debug.Log("b");
					if (!gameObjectsList[nullObj.number][i].activeSelf)
					{
						GameObject createObj = gameObjectsList[nullObj.number][i];
						createObj.SetActive(true);
						createObj.transform.position = pos;
						return createObj;
					}
				}
			}
			GameObject instance = Instantiate(nullObj.obj) as GameObject;
			gameObjectsList.Add(new List<GameObject>());
			gameObjectsList[nullObj.number].Add(instance);
			instance.transform.position = pos;
			return instance;

		}
		else
		{
			// Debug.Log(effectKey + "に対応したEffectはありません");
			return null;
		}
	}*/

	public GameObject GetCreateObject(string key, Vector3 pos, float lifeTime)
	{
		if (dictuinary.TryGetValue(key, out nullObj))
		{
			int count = objDataList[nullObj.number].objList.Count;
			for (i = 0; i < count; i++)
			{
				if (!objDataList[nullObj.number].objList[i].activeSelf) //非表示のオブジェクトがあったとき
				{
					//Debug.Log("オブジェクトを再表示");
					GameObject createObj = objDataList[nullObj.number].objList[i];
					createObj.SetActive(true);
					createObj.transform.position = pos;
					StartCoroutine(DestroyObject(createObj, lifeTime));
					return createObj;
				}
				
			}
			//非表示のオブジェクトがなかった時
			//Debug.Log("オブジェクトを生成");
			GameObject instance = Instantiate(nullObj.obj) as GameObject;
			objDataList[nullObj.number].AddObject(instance, pos);
			StartCoroutine(DestroyObject(instance, lifeTime));

			return instance;
		}
		else
		{
			// Debug.Log(effectKey + "に対応したEffectはありません");
			return null;
		}
	}

	private IEnumerator DestroyObject(GameObject obj,float lifeTime)
	{
		yield return new WaitForSeconds(lifeTime);
		obj.SetActive(false);
	}
	/*private void DestroyObject(GameObject obj)
	{
		obj.SetActive(false);
	}*/
}
