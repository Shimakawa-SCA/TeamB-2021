using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//Serializableに必要らしい（一応付けてるだけ
using UnityEditor;



public class NewPlayerScript : MonoBehaviour
{

    public bool Waiting;//待機
    public bool Hold;//持つ
    public bool Move;//移動
    public bool HoldingMove;//持って移動
    public bool Jump;//ジャンプ
    public bool HoldingJump;//持ってジャンプ
    public bool Death1;//死亡１
    public bool CanMove;//移動許可

    public bool PlayerRight;//プレイヤーの方向

    public static int RCount;

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
    public bool GetJumpInput;//ジャンプの入力を受け付けるかどうか
    bool IsJump;//ジャンプしてるかどうか
    bool Keep;//耐空中かどうか
    bool Fall;//落下するかどうか
    int Ji;//UpDate内で連続呼び出しさせない用
    int Fi;//上に同じ

    float LSH;//左スティックの水平軸
    float MoveDirection;//動作テスト用

    bool CanHold;//持てるかどうか
    bool Canswitching;//操作できるかどうか

    bool JumpUping;//上昇中
    bool JumpFalling;//落下中
    bool JumpKeeping;//耐空中

    public bool AnimationWaitRight;//アニメーション用
    public bool AnimationMoveRight;
    public bool AnimationJumpRight;
    public bool AnimationHoldRight;
    public bool AnimationHoldingMoveRight;
    public bool AnimationHoldingJumpRight;
    public bool AnimationDeath1Right;
    public bool AnimationWaitLeft;
    public bool AnimationMoveLeft;
    public bool AnimationJumpLeft;
    public bool AnimationHoldLeft;
    public bool AnimationHoldingMoveLeft;
    public bool AnimationHoldingJumpLeft;
    public bool AnimationDeath1Left;
    public bool AnimationJumpUpingRight;
    public bool AnimationJumpUpingLeft;
    public bool AnimationJumpKeepingRight;
    public bool AnimationJumpKeepingLeft;
    public bool AnimationJumpFallingRight;
    public bool AnimationJumpFallingLeft;

    bool JF1;//落下アニメーション用
    bool JF2;
    bool JF3;
    bool JF4;

    public bool AnimationJF;

    float[] stetus;//ステージごとのステータス
    int Stagenumber;//ステージ数
    int stetusnumber;
    Vector3 PlayerSpawnPoint;//スポーン地点

    int PlayerHoldItem;//何を持っているか
    public bool ItemHold; //アイテムをもっているか

    float LandingSticking;//膠着時間

    public GameObject ActiveBom;//使用した爆弾
    Vector3 ItemDropPoint;//アイテムを落とす場所
    Quaternion bomq;

    Vector3 PlayerPosition; 
    

    public GameObject cadaver;//死体
    public GameObject cadaverl;

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
        Stagenumber = 2;
        SetUp();
        PlayerRight = true;
        Ji = 0;
        Fi = 0;
        JF1 = false;
        JF2 = false;
        JF3 = false;
        JF4 = false;
        CanHold = false;
        stetus = new float[21] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
        PlayerHoldItem = 0;
        stetusnumber = 0;
        LandingSticking = 0.5f;
        transform.position = PlayerSpawnPoint;
        bomq = Quaternion.Euler(0, 0, 0);
    }

    public void SetUp()
    {
        CanMove = true;
        Waiting = false;
        Hold = false;
        Move = false;
        HoldingMove = false;
        Jump = false;
        Death1 = false;
        IsFlor = false;
        IsJump = false;

        rb.velocity = new Vector3(rb.velocity.x, 0, 0);

        if (Stagenumber == 1)
        {

            PlayerSpawnPoint = new Vector3(0, -2.5f, 0);
        }
        if (Stagenumber == 2)
        {

            PlayerSpawnPoint = new Vector3(-7.5f, 1.5f, 0);
        }
        if (Stagenumber == 3)
        {
            JumpForce = stetus[14];
            InputReceiveTime = stetus[15];
            KeepStart = stetus[16];
            KeepForce = stetus[17];
            FlightDuration = stetus[18];
            FallStart = stetus[19];
            FallSpeed = stetus[20];
            PlayerSpawnPoint = new Vector3(0, 4.2f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = transform.position;
        ItemDropPoint = new Vector3(transform.position.x + 0.5f, transform.position.y, 0);
        if (Input.GetKeyDown(KeyCode.R))
        {
            TimeCounter.tTime = 1;
            Debug.Log(TimeCounter.tTime);
            RCount += 1;
            Debug.Log(RCount);
            if (PlayerRight ==true)
            {
                Instantiate(cadaver, PlayerPosition,bomq);
                SetUp();
            }
            if (PlayerRight == false)
            {
                Instantiate(cadaverl, PlayerPosition,bomq);
                SetUp();
            }
            transform.position = PlayerSpawnPoint;
        }


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
            TimeCounter.tTime = 1;
            Debug.Log(TimeCounter.tTime);
        }
        if (Input.GetKey(KeyCode.D)) //動作テスト用
        {
            LSH = 0.5f;
            TimeCounter.tTime = 1;
            Debug.Log(TimeCounter.tTime);
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
            if (LSH != 0)
            {
                if(CanMove == true)
                {
                    Move = true;
                }
                Waiting = false;
                if (LSH < 0)
                {
                    MoveDirection = -1;
                    PlayerRight = false;
                }
                if (LSH > 0)
                {
                    MoveDirection = 1;
                    PlayerRight = true;
                }
                rb.velocity = new Vector3(Speed * MoveDirection, rb.velocity.y, 0);
            }
        }
        if (Input.GetKeyUp(KeyCode.A)) LSH = 0;//動作テスト用
        if (Input.GetKeyUp(KeyCode.D)) LSH = 0;//動作テスト用

        if (LSH == 0) Move = false;//スティックの入力で動いているかどうか判断
        if (Input.GetKey(KeyCode.Space))//Aボタン
        {
            if (CanMove == true && IsFlor == true)//ジャンプの許可
            {
                IsFlor = false;//床から離れる
                Jump = true;//ジャンプ状態に入る
                Waiting = false;//待機状態から抜ける
                GetJumpInput = true;//ジャンプ入力の受付開始
                Invoke("StopJumpInput", InputReceiveTime);//ジャンプ入力の受付時間制御
                if (GetJumpInput == true)//入力受付中の速度代入
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
            //Debug.Log(Ji);
        }

        if (Input.GetKeyUp(KeyCode.Space))//最大ジャンプ前に放したとき
        {
            GetJumpInput = false;//受付時間を無視してfalseに
            Invoke("KeepS", KeepStart);//耐空開始へ
        }

        if (Keep == true) rb.AddForce(0, KeepForce, 0);//耐空中の処理
        if (Fall == true) rb.AddForce(0, -FallSpeed, 0);//落下中の処理
        float pvy = rb.velocity.y;
        if (Jump == true)
        {
            if (pvy > 0) JumpUping = true;
            if (pvy < -0 / 1f)
            {
                JumpFalling = true;
                JumpUping = false;
                JumpKeeping = false;
            }
        }

        if (CanMove == false) Waiting = true;//バグ対策になるかな、一応つけとこ。
        if (Hold == false && Move == false && HoldingMove == false && Jump == false && HoldingJump == false)
        {
            Waiting = true;//入力が無ければ待機状態に
        }


        //ここからアニメーション
        Animator animator = GetComponent<Animator>();
        int Animaint = animator.GetInteger("Animationint");
        if (Waiting == true)
        {
            if (PlayerRight == true)
            {
                Animaint = 0;
            }
            if (PlayerRight == false)
            {
                Animaint = 1;
            }
        }
        //入力があるかないか
        if (Hold == true)//持った状態（持った状態で待機があれば追加
        {

            if (Jump == true)//最優先は持った状態でジャンプ
            {
                if (PlayerRight == true)
                {
                    if (JumpUping == true)
                    {
                        Animaint = 18;
                    }
                    if (JumpKeeping == true)
                    {
                        Animaint = 20;
                    }
                    if (AnimationJF == true)
                    {
                        Animaint = 22;
                        AnimationJF = false;
                    }
                }
                if (PlayerRight == false)
                {
                    if (JumpUping == true)
                    {
                        Animaint = 19;
                    }
                    if (JumpKeeping == true)
                    {
                        Animaint = 21;
                    }
                    if (AnimationJF == true)
                    {
                        Animaint = 23;
                        AnimationJF = false;
                    }
                }
            }
            if (Move == true && Jump == false)//次に優先
            {
                if (PlayerRight == true)
                {
                    Animaint = 6;
                }
                if (PlayerRight == false)
                {
                    Animaint = 7;
                }
            }
            if (Move == false && Jump == false)//移動していないとき
            {
                if (PlayerRight == true)
                {
                    Animaint = 4;
                }
                if (PlayerRight == false)
                {
                    Animaint = 5;
                }
            }
        }
        if (Jump == true && Hold == false)//普通のジャンプ
        {
            if (PlayerRight == true)
            {
                if (JumpUping == true)
                {
                    Animaint = 12;
                }
                if (JumpKeeping == true)
                {
                    Animaint = 14;
                }
                if (AnimationJF == true)
                {
                    Animaint = 16;
                    AnimationJF = false;
                }
            }
            if (PlayerRight == false)
            {
                if (JumpUping == true)
                {
                    Animaint = 13;
                }
                if (JumpKeeping == true)
                {
                    Animaint = 15;
                }
                if (AnimationJF == true)
                {
                    Animaint = 17;
                    AnimationJF = false;
                }
            }
        }
        if (Move == true && Hold == false && Jump == false)//移動
        {
            if (PlayerRight == true)
            {
                Animaint = 2;
            }
            if (PlayerRight == false)
            {
                Animaint = 3;
            }
        }
        if (JF1 == true)
        {
            Animaint = 22;
            JF1 = false;
        }
        if (JF2 == true)
        {
            Animaint = 23;
            JF2 = false;
        }
        if (JF3 == true)
        {
            Animaint = 16;
            JF3 = false;
        }
        if (JF4 == true)
        {
            Animaint = 17;
            JF4 = false;
        }
        animator.SetInteger("Animationint", Animaint);
    }

    public void Pose()//要協議
    {
        Waiting = false;
        Hold = false;
        Move = false;
        HoldingMove = false;
        Jump = false;
        Death1 = false;
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
        Debug.Log("j1");
    }

    public void KeepS()//ADDForceで耐空（第二段階
    {
        Keep = true;
        Invoke("KeepDone", FlightDuration);//耐空時間制御
        JumpKeeping = true;
        Debug.Log("j2");
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
        Debug.Log("j3");
    }

    public void FallStop()//落下終了、ジャンプ終了
    {
        Keep = false;
        Fall = false;
        Jump = false;
    }

    public void PR()
    {
        Animator animator = GetComponent<Animator>();
        int Animaint = animator.GetInteger("Animationint");
        Animaint = 24;
        animator.SetInteger("Animationint", Animaint);
    }

    public void RS()
    {
        CanMove = true;
    }



    private void OnCollisionEnter(Collision collision)//当たり判定
    {
        if ((collision.gameObject.tag == "Flor") || (collision.gameObject.tag == "player"))//タグで床にあたる
        {
            AC();
            FallStop();//落下終了処理
            IsFlor = true;//地面についている状態
            Fi += 1;
            //AnimationJF = true;
            JumpFalling = false;
            if (Fi == 1)//1は地面についた瞬間
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);//着地した瞬間落下速度を０に
                CanMove = false;
                Invoke("RS", LandingSticking);
            }
        }

        if (collision.gameObject.tag == "")//岩とぶつかったとき
        {
            Death1 = true;
            if (PlayerHoldItem != 0)
            {

            }
        }
    }

    public void AC()//着地したとき
    {
        Animator animator = GetComponent<Animator>();
        int Animaint = animator.GetInteger("Animationint");
        if (Hold == true)
        {
            if (Jump == true)
            {
                if (PlayerRight == true)
                {
                    JF1 = true;
                }
                if (PlayerRight == false)
                {
                    JF2 = true;
                }
            }
        }
        if (Hold == false)
        {
            if (Jump == true)
            {
                if (PlayerRight == true)
                {
                    JF3 = true;
                }
                if (PlayerRight == false)
                {
                    JF4 = true;
                }
            }
        }
        animator.SetInteger("Animationint", Animaint);
    }

    private void OnCollisionExit(Collision collision)//ジャンプしないで落下したとき
    {
        /*Animator animator = GetComponent<Animator>();
        int Animaint = animator.GetInteger("Animationint");
        if (Jump == false)
        {
            if (collision.gameObject.tag == "Flor")
            {
                if(PlayerRight == true)
                {
                    Animaint = 30;
                }
                if(PlayerRight == false)
                {
                    Animaint = 31;
                }
            }
        }
        animator.SetInteger("Animationint", Animaint);
        */
    }

    public void SetStagenumber(int stn)//ステージ数の受け渡し
    {
        Stagenumber = stn;
    }

    private void OnTriggerStay(Collider other)//アイテムを入手
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (ItemHold == false)
            {
                if (collision.gameObject.tag == "Bom")
                {
                    ItemHold = true;
                    PlayerHoldItem = 1;
                    transform.parent = collision.transform;
                }
                if (collision.gameObject.tag == "Item2")
                {
                    ItemHold = true;
                    PlayerHoldItem = 2;
                    transform.parent = collision.transform;
                }
                if (collision.gameObject.tag == "Item3")
                {
                    ItemHold = true;
                    PlayerHoldItem = 3;
                    transform.parent = collision.transform;
                }
            }
        }

        if (collision.gameObject.tag == "")//レバー
        {


        }

        if (collision.gameObject.tag == (""))//アイテムを使用できる場所
        {
            ItemHold = false;
            if ((PlayerHoldItem == 1) || (PlayerHoldItem == 2))
            {
                this.transform.DetachChildren();
            }
            if (PlayerHoldItem == 3)
            {
                GameObject bomobject = transform.GetChild(1).gameObject;
                Destroy(bomobject);
                GameObject PrefabBom = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab.bom");
                Instantiate(PrefabBom, ItemDropPoint, bomq);
            }
        }
    }
}
