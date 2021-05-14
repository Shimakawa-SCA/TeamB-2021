using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public bool pausing = false;

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

	//ポーズボタンhttp://kuromikangames.com/article/476587788.html
	[SerializeField] private Button pauseButton;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private Button resumeButton;
	[SerializeField] private Button retryButton;
	[SerializeField] private Button titleButton;

	//ポーズ処理
	void Start()
	{
		pausePanel.SetActive(false);
		pauseButton.onClick.AddListener(Pausefor);
		resumeButton.onClick.AddListener(Resumefor);
		retryButton.onClick.AddListener(OnClick);
		titleButton.onClick.AddListener(OnClickT);

	}
	// 更新処理
	void Update()
	{

		// ポーズ状態が変更されていたら、Pause/Resumeを呼び出す。
		if (prevPausing != pausing)
		{
			if (pausing) Pause();
			else  Resume();
			prevPausing = pausing;
		}
	}
	void Pausefor()//bool値の真
    {
		pausing = true;
	}
	void Resumefor()//bool値の偽
	{
		pausing = false;
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
		Time.timeScale = 0;  // 時間停止
		pausePanel.SetActive(true);//メニューを開く
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
		Time.timeScale = 1;  // 再開
		pausePanel.SetActive(false);//メニューを閉じる
	}
	//やり直しボタン
	public void OnClick()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		pausing = false;
	}
	//タイトルに行くボタン
	public void OnClickT()
	{
		SceneManager.LoadScene("Opening");
		pausing = false;
	}
}

