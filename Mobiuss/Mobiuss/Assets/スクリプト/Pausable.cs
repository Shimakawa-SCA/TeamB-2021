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
	[SerializeField] private Button SelectButton;
	[SerializeField] private Button SelectButtont;

	public static int NotMenuCount;

	//ポーズ処理
	void Start()
	{
		pausePanel.SetActive(false);
		pauseButton.onClick.AddListener(Pausefor);
		resumeButton.onClick.AddListener(Resumefor);
		retryButton.onClick.AddListener(OnClick);
		titleButton.onClick.AddListener(OnClickT);
		NotMenuCount = 0;
}
	// 更新処理
	void Update()
	{
        if (NotMenuCount == 0 ) 
		{
			if (Input.GetKeyDown("joystick button 7"))
			{
				pausing = !pausing;

				if (pausing == true)
				{
				Pause();
				}
				else
				{
				Resume();
				}
			}	
			// ポーズ状態が変更されていたら、Pause/Resumeを呼び出す。
			/*if (prevPausing != pausing)
			{
				if (pausing) Pause();
				else Resume();
				prevPausing = pausing;
			}*/ 
		}
		//D　Padの反応
		/*float dph = Input.GetAxis("D_Pad_H");
		float dpv = Input.GetAxis("D_Pad_V");
		if ((dph != 0) || (dpv != 0))
		{
			Debug.Log("D Pad:" + dph + "," + dpv);
		}*/
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
		//メニューを開く音
		NewSoundScriot.Menu1 = true;
		//ボタンが選択された状態になる
		SelectButton.Select();
	}

	// 再開
	public void Resume()
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

		//ボタンが選択された状態になる
		SelectButtont.Select();
		//ボタンを押す音
		NewSoundScriot.MenuButton1 = true;
		pausePanel.SetActive(false);//メニューを閉じる
	}
	//やり直しボタン
    public void OnClick()
	{
		FadeController2.isFadeOut = true;
		Invoke("Retry", 2.0f);
		//ボタンを押す音
		NewSoundScriot.MenuButton1 = true;
		pausing = false;
		Time.timeScale = 1;  // 再開
	}
	void Retry()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	//タイトルに行くボタン
	public void OnClickT()
	{
		Time.timeScale = 1;  // 再開
	　　//ボタンを押す音
		NewSoundScriot.MenuButton1 = true;
		pausing = false;
		FadeController2.isFadeOut = true;
		Invoke("Title", 2.0f);
	}
	void Title()
	{
		SceneManager.LoadScene("Prologue");
	}
}

