using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

	//　非同期動作で使用するAsyncOperation
	private AsyncOperation async;
	//　シーンロード中に表示するUI画面
	[SerializeField]
	private GameObject loadUI;
	//　読み込み率を表示するスライダー
	[SerializeField]
	private Slider slider;
	public Text loadText;

	public void NextScene()
	{
		//　ロード画面UIをアクティブにする
		loadUI.SetActive(true);

		//　コルーチンを開始
		StartCoroutine("LoadData");
		Invoke("Loadone",1.5f);
	}

	IEnumerator LoadData()
	{
		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync("Stage1");

		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while (!async.isDone)
		{
			var progressVal = Mathf.Clamp01(async.progress / 0.9f);
			slider.value = progressVal;
			yield return null;
		}
	}
	void Loadone()
	{
		loadText.text ="NowLoading";
		Invoke("Loadsecond",1.5f);
	}

	void Loadsecond()
    {
		loadText.text = "NowLoading.";
		Invoke("Loadthird", 1.5f);
	}
	void Loadthird()
	{
		loadText.text = "NowLoading..";
		Invoke("Loadfourth", 1.5f);
	}
	void Loadfourth()
	{
		loadText.text = "NowLoading...";
		Invoke("Loadone", 1.5f);
	}
}