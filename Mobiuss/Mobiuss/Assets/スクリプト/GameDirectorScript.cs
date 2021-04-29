using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorScript : MonoBehaviour
{
    //作たけ
    public GameObject Player;
    Vector3 GPos;
    Quaternion q;
    public int i = 0;
    //　出現させるエフェクト
    [SerializeField]
    private GameObject effectObject;
    //　エフェクトを消す秒数
    [SerializeField]
    private float deleteTime;
    //　エフェクトの出現位置のオフセット値
    [SerializeField]
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        GPos = new Vector3(0, -2, 0);
        q = Quaternion.Euler(0, 0, 0);
        //GameObject obj =　子分にしたくて追加しましたポーズに使います
        GameObject obj = Instantiate(Player, GPos, q);
        // 作成したオブジェクトを子として登録
        obj.transform.parent = transform;
        FindObjectOfType<PlayerScript>().getnnumber();
        FindObjectOfType<PlayerScript>().getnext();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<PlayerScript>().getnext();
            GameObject obj = Instantiate(Player, GPos, q);
            obj.transform.parent = transform;
            i += 1;
            Debug.Log(i);
            //　ゲームオブジェクト登場時にエフェクトをインスタンス化
            var instantiateEffect = GameObject.Instantiate(effectObject, transform.position + new Vector3(0f, offset, 0f), Quaternion.identity) as GameObject;
            Destroy(instantiateEffect, deleteTime);
        }
        
    }
}
