﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakesanPlayerScript2 : MonoBehaviour
{
    Rigidbody rb;
    public static Vector3 playerposition;
    float blx;
    float LSH;
    float MoveDirection;
    public static float Speed;
    public static bool PlayerRight;
    public bool Move;

    public static bool CanMove;
    public bool DoJump;
    int JumpTimeLine;
    public int FirstJumpProcessRange;
    public int SecondJumpRrocessRange;
    public float JumpForce;
    public float JumpKeepForce;
    int JumpStatusNumber;

    public GameObject cadaver;
    public GameObject cadaverl;
    Quaternion q;
    public static bool respornstack;
    Vector3 PlayerSpownpoint;

    public static bool Hold;
    bool PlayerDeth;
    public bool Wait;

    public static int R2Count;
    int jk = 0;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        rb = GetComponent<Rigidbody>();
        q = Quaternion.Euler(0, 0, 0);
        LSH = 0;
        CanMove = true;
        JumpTimeLine = 0;
        JumpStatusNumber = 0;
        PlayerSpownpoint = new Vector3(-6.5f,2,0);
        Hold = false;
        Move = false;
        PlayerRight = true;
        R2Count = 0;
        respornstack = false;
        Speed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDeth == true) PlayerDeth = false;
        GetPlayerPosition();
        VectolxBorderLine();
        if(CanMove == true){
            GetLStickHorizontal();
            //if (Input.GetButtonDown("")) DoJump = true;
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown("joystick button 0")) DoJump = true;
            //if (Input.GetButtonDown(""))
            if (respornstack == false){
                if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 2")) ReSpown();
            }
                
        }
        AddSpeed();
        if (DoJump  == true) Jump();
        Playerdirection();
        JumpStatus();
        LimitSpeed();
        GetPlayerStatus();
    }


    void GetPlayerPosition(){
        playerposition = transform.position;
    }

    void VectolxBorderLine(){
        if (Mathf.Abs(this.transform.position.x) > 8.5f) transform.position = new Vector3(blx, transform.position.y);
        blx = this.transform.position.x;
    }

    void GetLStickHorizontal(){
        //LSH = Input.GetAxis("???");//"設定値"（スティックの入力
        LSH = Input.GetAxis("L_Stick_H");
        if (Input.GetKeyDown(KeyCode.A)) LSH = -0.5f;
        if (Input.GetKeyDown(KeyCode.D)) LSH = 0.5f;
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) LSH = 0;
        if (LSH < 0) MoveDirection = -1;
        if (LSH > 0) MoveDirection = 1;
    }

    void AddSpeed(){
        if (LSH != 0){
            rb.velocity = new Vector3(Speed*MoveDirection,rb.velocity.y,0); 
            Wait = false;
            if (DoJump == false) Move = true;
            //タイマーを起動させる用
            TimeCounter2.tTime2 = 1;
            NewSoundScriot.Run1 = true;

        }
    }

    void Jump() {
        if (jk == 0)
        {
            NewSoundScriot.Jump1 = true;
            jk = 1;
        }
        if (JumpTimeLine <= SecondJumpRrocessRange) JumpTimeLine++;
        if (JumpTimeLine <= FirstJumpProcessRange)
        {
            FirstJumpProcess();
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp("joystick button 0")) JumpTimeLine = FirstJumpProcessRange;
        }
        if (JumpTimeLine > FirstJumpProcessRange && JumpTimeLine <= SecondJumpRrocessRange) SecondJumpProcess();
    }

    void FirstJumpProcess(){
        rb.velocity = new Vector3(rb.velocity.x,JumpForce);
    }

    void SecondJumpProcess(){
        rb.AddForce(0,JumpKeepForce,0);
    }

    void Playerdirection(){
        if (LSH < 0) PlayerRight = false;
        if (LSH > 0) PlayerRight = true;
    }

    void JumpStatus(){
        float JumpVelocityy = rb.velocity.y;
        if (JumpVelocityy == JumpForce) {
            JumpStatusNumber = 1;
            Move = false;
        }
        if (JumpStatusNumber == 1){
            if ((JumpVelocityy > 0) && (JumpVelocityy != JumpForce)) JumpStatusNumber = 2;
        }
        if ((JumpStatusNumber == 1) || (JumpStatusNumber == 2)){
            if (JumpVelocityy < 0) JumpStatusNumber = 3;
        }
        if ((JumpVelocityy == 0) && (JumpStatusNumber == 3)){
            JumpStatusNumber = 4;
            DoJump = false;
            JumpTimeLine = 0;
            rb.velocity = new Vector3(rb.velocity.x,0,0);
        }
        //Debug.Log(JumpStatusNumber);
    }

    void LimitSpeed(){
        if (rb.velocity.x > Speed ){
            rb.velocity = new Vector3(Speed, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.y > JumpForce){
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
        }
    }

    private void OnCollisionStay(Collision collision){
        if ((collision.gameObject.tag == ("Flor")) || (collision.gameObject.tag == ("iwa")))
        {
            if (JumpStatusNumber == 3){
                JumpStatusNumber = 4;
                DoJump = false;
                JumpTimeLine = 0;
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            }
            if (JumpStatusNumber == 2){
                JumpStatusNumber = 4;
                DoJump = false;
                JumpTimeLine = 0;
            }
            if (JumpStatusNumber == 1){
                if (rb.velocity.y == 0){
                    JumpTimeLine = FirstJumpProcessRange;
                }
            }
        }
    }

    void ReSpown(){
        if (PlayerRight == true){
            Invoke("RightDeth", 1.05f);
        }
        if (PlayerRight == false){
            Invoke("LeftDeth", 1.05f);
        }
        R2Count++;
        CanMove = false;
        PlayerDeth = true;
        respornstack = true;
        FindObjectOfType<getplayerScript>().repd();
        Invoke("RespornReset", 1);
    }

    void RespornReset(){
        respornstack = false;
    }

    void RightDeth(){
        Instantiate(cadaver,playerposition,q);
        SetUp();
    }

    void LeftDeth(){
        Instantiate(cadaverl, playerposition, q);
        SetUp();
    }

    void SetUp(){
        JumpStatusNumber = 0;
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = PlayerSpownpoint;
        LSH = 0;
        DoJump = false;
        CanMove = true;
        PlayerRight = true;
    }

    void GetPlayerStatus(){
        Animator animator = GetComponent<Animator>();
        int Animaint = animator.GetInteger("Animationint");
        if (LSH == 0){
            NewSoundScriot.i = 0;
            Wait = true;
            Move = false;
        }
        if (Hold == true){
            if (DoJump == false){
                if (Wait == true){
                    if (PlayerRight == true){
                        Animaint = 12;
                    }
                    if (PlayerRight == false){
                        Animaint = 13;
                    }
                }
                if (Move == true){
                    if (PlayerRight == true){
                        Animaint = 14;
                    }
                    if (PlayerRight == false){
                        Animaint = 15;
                    }
                }
            }
            if (DoJump == true){
                if (JumpStatusNumber == 1){
                    if (PlayerRight == true){
                        Animaint = 16;
                    }
                    if (PlayerRight == false){
                        Animaint = 17;
                    }
                }
                if (JumpStatusNumber == 2){
                    if (PlayerRight == true){
                        Animaint = 18;
                    }
                    if (PlayerRight == false){
                        Animaint = 19;
                    }
                }
                if (JumpStatusNumber == 3){
                    if (PlayerRight == true){
                        Animaint = 20;
                    }
                    if (PlayerRight == false){
                        Animaint = 21;
                    }
                }
            }
            if (JumpStatusNumber == 4){
                NewSoundScriot.Landing1 = true;
                jk = 0;
                if (PlayerRight == true){
                    Animaint = 22;
                }
                if (PlayerRight == false){
                    Animaint = 23;
                }
            }
        }
        if (Hold == false){
            if (DoJump == false){
                if (Wait == true){
                    if (PlayerRight == true){
                        Animaint = 0;
                    }
                    if (PlayerRight == false){
                        Animaint = 1;
                    }
                }
                if (Move == true){
                    if (PlayerRight == true){
                        Animaint = 2;
                    }
                    if (PlayerRight == false){
                        Animaint = 3;
                    }
                }
            }
            if (DoJump == true){
                if (JumpStatusNumber == 1){
                    if (PlayerRight == true){
                        Animaint = 4;
                    }
                    if (PlayerRight == false){
                        Animaint = 5;
                    }
                }
                if (JumpStatusNumber == 2){
                    if (PlayerRight == true){
                        Animaint = 6;
                    }
                    if (PlayerRight == false){
                        Animaint = 7;
                    }
                }
                if (JumpStatusNumber == 3){
                    if (PlayerRight == true){
                        Animaint = 8;
                    }
                    if (PlayerRight == false){
                        Animaint = 9;
                    }
                }
            }
            if (JumpStatusNumber == 4){
                NewSoundScriot.Landing1 = true;
                jk = 0;
                if (PlayerRight == true){
                    Animaint = 10;
                }
                if (PlayerRight == false){
                    Animaint = 11;
                }
            }
        }
        if (PlayerDeth == true){
            if (PlayerRight == true){
                Animaint = 24;
            }
            if (PlayerRight == false){
                Animaint = 25;
            }
        }
        animator.SetInteger("Animationint", Animaint);
        if (JumpStatusNumber == 4) JumpStatusNumber = 0;
        Debug.Log(Animaint);
    }
}
