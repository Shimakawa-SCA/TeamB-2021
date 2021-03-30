using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Rigidbodyの速度を保存しておくクラス
public class RigidbodyVelocity
{
	public Vector3 velocity;
	public Vector3 angularVeloccity;
	public RigidbodyVelocity(Rigidbody rigidbody)
	{
		velocity = rigidbody.velocity;
		angularVeloccity = rigidbody.angularVelocity;
	}
}
public class Pausable : MonoBehaviour
{
  //現在Pause中か？
	public bool pausing;

	// 無視するGameObject
	public GameObject[] ignoreGameObjects;
    // ポーズ状態が変更された瞬間を調べるため、前回のポーズ状況を記録しておく
	bool prevPausing;

	// Rigidbodyのポーズ前の速度の配列
	RigidbodyVelocity[] rigidbodyVelocities;

	// ポーズ中のRigidbodyの配列
	Rigidbody[] pausingRigidbodies;

	// ポーズ中のMonoBehaviourの配列
	MonoBehaviour[] pausingMonoBehaviours;

	// 更新処理
	void Update()
	{
		// ポーズ状態が変更されていたら、Pause/Resumeを呼び出す。
		if (prevPausing != pausing)
		{
			if (pausing) Pause();
			else Resume();
			prevPausing = pausing;
		}
	}

	// 中断
	void Pause()
	{
		// Rigidbodyの停止
		// 子要素から、スリープ中でなく、IgnoreGameObjectsに含まれていないRigidbodyを抽出
		Predicate<Rigidbody> rigidbodyPredicate =
			obj => !obj.IsSleeping() &&
				   Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
		pausingRigidbodies = Array.FindAll(transform.GetComponentsInChildren<Rigidbody>(), rigidbodyPredicate);
		rigidbodyVelocities = new RigidbodyVelocity[pausingRigidbodies.Length];
		for (int i = 0; i < pausingRigidbodies.Length; i++)
		{
			// 速度、角速度も保存しておく
			rigidbodyVelocities[i] = new RigidbodyVelocity(pausingRigidbodies[i]);
			pausingRigidbodies[i].Sleep();
		}

		// MonoBehaviourの停止
		// 子要素から、有効かつこのインスタンスでないもの、IgnoreGameObjectsに含まれていないMonoBehaviourを抽出
		Predicate<MonoBehaviour> monoBehaviourPredicate =
			obj => obj.enabled &&
				   obj != this &&
				   Array.FindIndex(ignoreGameObjects, gameObject => gameObject == obj.gameObject) < 0;
		pausingMonoBehaviours = Array.FindAll(transform.GetComponentsInChildren<MonoBehaviour>(), monoBehaviourPredicate);
		foreach (var monoBehaviour in pausingMonoBehaviours)
		{
			monoBehaviour.enabled = false;
		}

	}

	// 再開
	void Resume()
	{
		// Rigidbodyの再開
		for (int i = 0; i < pausingRigidbodies.Length; i++)
		{
			pausingRigidbodies[i].WakeUp();
			pausingRigidbodies[i].velocity = rigidbodyVelocities[i].velocity;
			pausingRigidbodies[i].angularVelocity = rigidbodyVelocities[i].angularVeloccity;
		}

		// MonoBehaviourの再開
		foreach (var monoBehaviour in pausingMonoBehaviours)
		{
			monoBehaviour.enabled = true;
		}
	}
}

