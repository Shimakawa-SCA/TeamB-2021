using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTakesanPlayer : MonoBehaviour
{
    enum PlayerStatus
    {
        Wait,
        Move,
        Jump,
        HoldWait,
        HoldMove,
        HoldJump,
        Deth,
    }
    [SerializeField]PlayerStatus playerstatus = PlayerStatus.Wait;
    public float MoveSpeed;
    public float JumpForce;
    public float JumpKeepForce;
    public bool PlayerRight;
    public bool CanMove;
    bool Hold;
    int StageNumber;
    Rigidbody rb;
    float LStickHorizontal;
    bool IsGround;
    float MoveDirection;
    bool jump;
    int JumpTimeLine;
    [SerializeField] int FirstJumpProcessRange;
    [SerializeField] int SecondJumpRrocessRange;
    // Start is called before the first frame update
    void Start()
    {
        JumpTimeLine = 0;
        rb = GetComponent<Rigidbody>();
        Hold = false;
        PlayerRight = true;
        CanMove = false;
        jump = false;
        PassInitializ();
        GetPass();
        SetPass();
    }

    // Update is called once per frame
    void Update()
    {
        InputDirector();
        ActionDirector();
    }

    void PassInitializ(){
        Pass.PlayerPosition = transform.position;
        Pass.PlayerHold = Hold;
        Pass.PlayerRight = PlayerRight;
        Pass.PlayerCanMove = CanMove;
    }

    void GetPass(){
        CanMove = Pass.PlayerCanMove;
        StageNumber = Pass.StageNumber;
        Hold = Pass.PlayerHold;
    }

    void SetPass(){
        Pass.PlayerRight = PlayerRight;
        Pass.PlayerPosition = transform.position;
        Pass.PlayerHold = Hold;
    }

    void InputDirector(){
        if (CanMove == true){
            //LStickHorizontal = Input.GetAxis("L_Stick_H");
            if (Input.GetKeyDown(KeyCode.A)) LStickHorizontal = -0.5f;
            if (Input.GetKeyDown(KeyCode.D)) LStickHorizontal = 0.5f;
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) LStickHorizontal = 0;
            if (LStickHorizontal < 0) MoveDirection = -1;
            if (LStickHorizontal > 0) MoveDirection = 1;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) jump = true;
        }
    }

    void ActionDirector(){
        rb.velocity = new Vector3(MoveDirection,rb.velocity.y,0);
        if (jump) JumpDirector();
    }

    void JumpDirector(){
        if (JumpTimeLine < SecondJumpRrocessRange) JumpTimeLine++;
        if (JumpTimeLine <= FirstJumpProcessRange){
            rb.velocity = new Vector3(rb.velocity.x, JumpForce);
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp("joystick button 0")) JumpTimeLine = FirstJumpProcessRange;
        }
        if (JumpTimeLine > FirstJumpProcessRange && JumpTimeLine <= SecondJumpRrocessRange) rb.AddForce(0, JumpKeepForce, 0);
    }

    private void OnCollisionStay(Collision collision){
        if ((collision.gameObject.tag == "Flor") || (collision.gameObject.tag == "iwa")){

        }
    }
}
