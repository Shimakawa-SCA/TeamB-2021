using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcontroll : MonoBehaviour
{
    // 速度
    Quaternion Q;
    Quaternion Z;
    public Vector2 SPEED = new Vector2(0.05f, 0.05f);
    private Rigidbody rb;
    public GameObject CubePrefab;
    // Use this for initialization
    void Start()
{
        rb = GetComponent<Rigidbody>();
        Q = Quaternion.Euler(0f,180f,0f);
        Z = Quaternion.Euler(0f, 0f, 0f);
    }

// Update is called once per frame
void Update()
{
    // 移動処理
    Move();
}

// 移動関数
void Move()
{
    // 現在位置をPositionに代入
    Vector2 Position = transform.position;
    // 左キーを押し続けていたら
    if (Input.GetKey(KeyCode.A))
    {
        // 代入したPositionに対して加算減算を行う
        Position.x -= SPEED.x;
        transform.rotation = Q;
    }
    else if (Input.GetKey(KeyCode.D))
    { // 右キーを押し続けていたら
      // 代入したPositionに対して加算減算を行う
        Position.x += SPEED.x;
            transform.rotation = Z;
        }
    if (Input.GetKeyDown(KeyCode.Space))
    { // 上キーを押し続けていたら
      // 代入したPositionに対して加算減算を行う
            rb.velocity=new Vector3(0, 7.0f, 0);
        }
    /*else if (Input.GetKey("S"))
    { // 下キーを押し続けていたら
      // 代入したPositionに対して加算減算を行う
        Position.y -= SPEED.y;
    }*/
    // 現在の位置に加算減算を行ったPositionを代入する
    transform.position = Position;
}
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "yuka")
        {
            Instantiate(CubePrefab, new Vector3(1.0f, -3.0f, 0.0f), Quaternion.identity);
            Destroy(gameObject);

        }
    }


}
