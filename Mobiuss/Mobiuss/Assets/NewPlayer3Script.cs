using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer3Script : MonoBehaviour
{
    public bool PlayerRight;
    public bool Waiting;
    public bool Move;
    public bool Jump;
    public bool Hold;
    public bool JumpUping;
    public bool JumpKeeping;
    public bool AnimationJF;
    bool JF1;
    bool JF2;
    bool JF3;
    bool JF4;
    bool HoldingMove;
    bool HoldingJump;

    public float Speed;
    float LSH;
    float MoveDirection;

    bool IsFlor;
    int J1;
    int J2;
    int J3;
    bool JumpUp;
    bool JumpKeep;
    bool JumpFall;
    public int jumpup;
    public int jumpkeep;
    public int jumpfall;
    public float JumpForce;
    public float KeepForce;

    Vector3 PlayerSpownPoint;
    Vector3 PlayerPosition;

    public GameObject cadaver;
    public GameObject cadaverl;
    Quaternion bomq;
    int repoint;
    int dethstack;

    public bool CanHold;
    float bomdistance;
    float canuseposition;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        J1 = 0;
        J2 = 0;
        J3 = 0;
        PlayerSpownPoint = new Vector3(0,0,0);
        bomq = Quaternion.Euler(0, 0, 0);
        repoint = 0;
        dethstack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            LSH = -0.5f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            LSH = 0.5f;
        }
        if (LSH != 0)
        {
            Move = true;
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
        FindObjectOfType<bom>().getright(PlayerRight);
        if (Input.GetKeyUp(KeyCode.A)) LSH = 0;
        if (Input.GetKeyUp(KeyCode.D)) LSH = 0;
        if (LSH == 0) Move = false;

        if (Input.GetKey(KeyCode.Space))
        {
            if (IsFlor == true)
            {
                IsFlor = false;
                Jump = true;
                Waiting = false;
                JumpUp = true;
                JumpUping = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            J1 = jumpup;
        }
        if (J1 == 1)JumpUping = false;
        if (JumpUp == true)
        {
            J1 += 1;
        }
        if (J1 > jumpup)
        {
            JumpUp = false;
            JumpKeep = true;
            JumpKeeping = true;
        }
        if (J2 > 1)JumpKeeping = false;
        if (JumpKeep == true)
        {
            J2 += 1;
        }
        if (J2 > jumpkeep)
        {
            JumpKeep = false;
        }
        if (JumpUp == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
        }
        if (JumpKeep == true)
        {
            rb.AddForce(0, KeepForce, 0);
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            if (bomdistance < 1 && Hold == false)
            {
                Hold = true;
            }
            if (canuseposition < 1 && Hold == true)
            {
                Hold = false;
            }
        }

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
        if (Hold == false && Move == false && HoldingMove == false && Jump == false && HoldingJump == false) Waiting = true;
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
        if (repoint == 1)
        {
            Animaint = 24;
            repoint = 0;
        }
        if (AnimationJF == true) AnimationJF = false;
        animator.SetInteger("Animationint", Animaint);
        if (Input.GetKeyDown(KeyCode.R))
        {
            Animator animator1 = GetComponent<Animator>();
            int Animaint1 = animator1.GetInteger("Animationint");
            PlayerPosition = transform.position;
            if (PlayerRight == true)
            {
                Invoke("PlayerDethR", 1);
                Animaint1 = 10;
            }
            if (PlayerRight == false)
            {
                Invoke("PlayerDethL", 1);
                Animaint1 = 11;
            }
            animator1.SetInteger("Animationint", Animaint1);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Flor") || (collision.gameObject.tag == "player"))
        {
            Jump = false;
            //AnimationJF = true;
            IsFlor = true;
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            if (Hold == true)
            {
                if(PlayerRight == true)
                {
                    JF1 = true;
                }
                if (PlayerRight == false)
                {
                    JF2 = true;
                }
            }
            if (Hold == false)
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
            Jump = false;
            J1 = 0;
            J2 = 0;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if((collision.gameObject.tag == "Flor") || (collision.gameObject.tag == "player")||(collision.gameObject.tag == "iwa"))
        {
            if(Jump == true)
            {
                Jump = false;
                //AnimationJF = true;
                IsFlor = true;
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                if (Hold == true)
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
                if (Hold == false)
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
                Jump = false;
                J1 = 0;
                J2 = 0;
            }
        }
    }

    void PlayerDethR()
    {
        Instantiate(cadaver, PlayerPosition, bomq);
        transform.position = new Vector3(PlayerSpownPoint.x, PlayerSpownPoint.y + 0.5f,0f);
        rb.velocity = new Vector3(0,0,0);
        repoint += 1;
    }
    void PlayerDethL()
    {
        Instantiate(cadaverl, PlayerPosition, bomq);
        transform.position = new Vector3(PlayerSpownPoint.x, PlayerSpownPoint.y + 0.5f, 0f); ;
        rb.velocity = new Vector3(0, 0, 0);
        repoint += 1;
    }

    public void setcanhold(float ii)
    {
        bomdistance = ii;
    }

    public void setcanuseposition(float jj)
    {
        canuseposition = jj;
    }
}
