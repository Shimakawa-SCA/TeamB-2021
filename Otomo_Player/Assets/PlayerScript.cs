using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//Serializableに必要らしい（一応付けてるだけ



public class PlayerScript : MonoBehaviour
{
    
    public bool Waiting;//待機
    public bool Hold;//持つ
    public bool Move;//移動
    public bool HoldingMove;//持って移動
    public bool Jump;//ジャンプ
    public bool HoldingJump;//持ってジャンプ
    public bool Death1;//死亡１
    public bool Death2;//死亡２
    public bool Death3;//死亡３
    public bool CanMove;//移動許可

    [Serializable]//インスペクターをきれいにするもの
    public class StatusValue
    {
        public float Speed;//速度
    }
    float Speed;//classのを取得する用
    [Serializable]
    public class JumpStatusValue//ジャンプに関する変数
    {
        public float JumpForce = 0.0f;//代入するジャンプ速度
        public float InputReceiveTime;//入力を受け付ける時間
        public float KeepStart;//耐空開始時間
        public float KeepForce;//耐空力
        public float FlightDuration;//耐空持続時間
        public float FallStart;//加速開始時間
        public float FallSpeed;//落下速度
    }
    float JumpForce;//代入するジャンプ速度
    float InputReceiveTime;//入力を受け付ける時間
    float KeepStart;//耐空開始時間
    float KeepForce;//耐空力
    float FlightDuration;//耐空持続時間
    float FallStart;//加速開始時間
    float FallSpeed;//落下速度

    public StatusValue statusValue;//取得
    public JumpStatusValue jumpStatusValue;//取得

    bool IsFlor;//地面に着いているか
    bool GetJumpInput;//ジャンプの入力を受け付けるかどうか
    bool IsJump;//ジャンプしてるかどうか
    bool Keep;//耐空中かどうか
    bool Fall;//落下するかどうか
    int Ji;//UpDate内で連続呼び出しさせない用
    int Fi;//上に同じ

    float LSH;//左スティックの水平軸
    float MoveDirection;//動作テスト用

    bool CanHold;//持てるかどうか
    bool Canswitching;//操作できるかどうか


    Rigidbody rb;//RigidBody

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Speed = statusValue.Speed;
        JumpForce = jumpStatusValue.JumpForce;
        InputReceiveTime = jumpStatusValue.InputReceiveTime;
        KeepStart = jumpStatusValue.KeepStart;
        KeepForce = jumpStatusValue.KeepForce;
        FlightDuration = jumpStatusValue.FlightDuration;
        FallStart = jumpStatusValue.FallStart;
        FallSpeed = jumpStatusValue.FallSpeed;
        SetUp();
        Ji = 0;
        Fi = 0;
        CanHold = false;
    }

    public void SetUp()
    {
        CanMove = false;
        Waiting = false;
        Hold = false;
        Move = false;
        HoldingMove = false;
        Jump = false;
        Death1 = false;
        Death2 = false;
        Death3 = false;
        IsFlor = false;
        IsJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (CanMove)//持つとギミック操作
        //{
        //    if (Input.GetKeyDown("???"))//Xボタン
        //    {
        //        //持てる箱があるかどうか(CanHold = true
        //        if (CanHold == true)
        //        {
        //            Hold = true;//持っている状態
        //        }
        //        //操作できるものがあるかどうか
        //        if (CanHold == false && Canswitching == true)
        //        {
        //            //操作
        //        }
        //        if (Hold == true)
        //        {
        //            //放す
        //            Hold = false;
        //        }
        //    }
        //}
        
        if (Input.GetKey(KeyCode.A)) //動作テスト用
        {
            LSH = -0.5f;

        }
        if (Input.GetKey(KeyCode.D)) //動作テスト用
        {
            LSH = 0.5f;

        }
        //if (CanMove == true)
        //{
        //    LSH = Input.GetAxis("???");//"設定値"（スティックの入力
        //    rb.velocity = new Vector3(Speed * LSH, rb.velocity.y, 0);//移動の計算と代入
        //    if (LSH != 0)
        //    {
        //        Move = true;//スティックの入力で動いているかどうか判断
        //    }
        //}

        if (CanMove == true)//動作テスト
        {
            if(LSH != 0)
            {
                Move = true;
                Waiting = false;
                if (LSH < 0) MoveDirection = -1;
                if (LSH > 0) MoveDirection = 1;
                rb.velocity = new Vector3(Speed * MoveDirection, rb.velocity.y, 0);
            }
        }
        if (Input.GetKeyUp(KeyCode.A)) LSH = 0;//動作テスト用
        if (Input.GetKeyUp(KeyCode.D)) LSH = 0;//動作テスト用

        if (LSH == 0) Move = false;//スティックの入力で動いているかどうか判断
        if(Input.GetKey(KeyCode.Space))//Aボタン
        {
            if(CanMove == true && IsFlor == true)//ジャンプの許可
            {
                IsFlor = false;//床から離れる
                Jump = true;//ジャンプ状態に入る
                Waiting = false;//待機状態から抜ける
                GetJumpInput = true;//ジャンプ入力の受付開始
                Invoke("StopJumpInput", InputReceiveTime);//ジャンプ入力の受付時間制御
                if(GetJumpInput == true)//入力受付中の速度代入
                {
                    DoJump();
                }
            }
            if (GetJumpInput == true) Ji = 0;//０は入力受付中
            if (GetJumpInput == false) Ji += 1;//毎フレーム+１
            if (Ji == 1) Invoke("KeepS", KeepStart);//falseになったフレームからkeepStart秒後耐空開始
            if (GetJumpInput == true)//falseになるまでここで最大ジャンプ
            {
                DoJump();
            }
        }
        
            if (Input.GetKeyUp(KeyCode.Space))//最大ジャンプ前に放したとき
            {
                GetJumpInput = false;//受付時間を無視してfalseに
                Invoke("KeepS", KeepStart);//耐空開始へ
            }
        
        if (Keep == true) rb.AddForce(0, KeepForce, 0);//耐空中の処理
        if (Fall == true) rb.AddForce(0, -FallSpeed, 0);//落下中の処理

        if (CanMove == false) Waiting = true;//バグ対策になるかな、一応つけとこ。
        if (Hold == false && Move == false && HoldingMove == false && Jump == false && HoldingJump == false)
        {
            Waiting = true;//入力が無ければ待機状態に
        }
        //ここからアニメーション
        if (Waiting == true)
        {

        }
        //入力があるかないか
        if (Hold ==true)//持った状態（持った状態で待機があれば追加
        {

            if(Jump == true)//最優先は持った状態でジャンプ
            {

            }
            if(Move == true && Jump == false)//次に優先
            {

            }
        }
        if (Jump == true && Hold == false)//普通のジャンプ
        {

        }
        if (Move == true && Hold == false && Jump == false)//移動
        {

        }
        
    }

    public void Pose()//要協議
    {
        Waiting = false;
        Hold = false;
        Move = false;
        HoldingMove = false;
        Jump = false;
        Death1 = false;
        Death2 = false;
        Death3 = false;
        IsFlor = false;
        IsJump = false;
    }

    public void StopJumpInput()//ジャンプ入力受付終了
    {
        GetJumpInput = false;
    }

    public void DoJump()//速度代入でジャンプ(第一段階
    {
        rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
    }

    public void KeepS()//ADDForceで耐空（第二段階
    {
        Keep = true;
        Invoke("KeepDone", FlightDuration);//耐空時間制御
    }
       
    public void KeepDone()//耐空終了
    {
        Keep = false;
        Invoke("FallS", FallStart);//落下開始制御
    }

    public void FallS()//AddForceで落下開始（第三段階
    {
        Fall = true;
        Fi = 0;
    }

    public void FallStop()//落下終了、ジャンプ終了
    {
        Fall = false;
        Jump = false;
    }

    private void OnCollisionEnter(Collision collision)//当たり判定
    {
        if (collision.gameObject.tag == "Flor")//タグで床にあたる
        {
            FallStop();//落下終了処理
            IsFlor = true;//地面についている状態
            Fi += 1;
            if(Fi == 1)//1は地面についた瞬間
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);//着地した瞬間落下速度を０に
            }
        }

    }
}
