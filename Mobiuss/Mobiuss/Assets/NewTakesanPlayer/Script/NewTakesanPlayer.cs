using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//タイミング300
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
    bool ajump;
    int JumpTimeLine;
    float blx;
    [SerializeField] int FirstJumpProcessRange;
    [SerializeField] int SecondJumpRrocessRange;
    bool Deth;
    bool sground;
    bool jump4;
    bool waitanimation;
    bool lfjump;
    bool respawnstack;
    // Start is called before the first frame update
    void Start()
    {
        JumpTimeLine = 0;
        rb = GetComponent<Rigidbody>();
        Hold = false;
        PlayerRight = true;
        CanMove = false;
        jump = false;
        ajump = false;
        PassInitializ();
        GetPass();
        SetPass();
        Deth = false;
        StageSteUp();
        waitanimation = false;
    }

    void StageSteUp(){
        if (StageNumber == 1) {
            FirstJumpProcessRange = 20;
            SecondJumpRrocessRange = 30;
        }
        if (StageNumber == 2) ;
        if (StageNumber == 3){
            transform.localScale = new Vector3(0.075f, 0.075f, 1);
            JumpForce = 2;
            JumpKeepForce = 1;
            FirstJumpProcessRange = 30;
            SecondJumpRrocessRange = 30;
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputDirector();
        ActionDirector();
        PlayerStatusDirector();
        if (waitanimation == false){
            PlayerAnimationDirector();
        }
        Border();
        latejumptf();
        GetPass();
        SetPass();
        Sound();
    }

    void Border(){
        if (Mathf.Abs(this.transform.position.x) > 8.5f) transform.position = new Vector3(blx, transform.position.y);
        blx = this.transform.position.x;
    }

    void PassInitializ(){
        Pass.PlayerPosition = transform.position;
        Pass.PlayerHold = Hold;
        Pass.PlayerRight = PlayerRight;
        Pass.PlayerCanMove = CanMove;
    }

    void GetPass(){
        CanMove = Pass.PlayerCanMove;
        Hold = Pass.PlayerHold;
        respawnstack = Pass.RespawnStack;
        StageNumber = Pass.StageNumber;
    }

    void SetPass(){
        Pass.PlayerRight = PlayerRight;
        Pass.PlayerPosition = transform.position;
        Pass.PlayerHold = Hold;
    }

    void InputDirector(){
        if (CanMove == true){
            LStickHorizontal = Input.GetAxis("L_Stick_H");
            if (Input.GetKey(KeyCode.A)) LStickHorizontal = -0.5f;
            if (Input.GetKey(KeyCode.D)) LStickHorizontal = 0.5f;
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) LStickHorizontal = 0;
            if (LStickHorizontal < 0) MoveDirection = -1;
            if (LStickHorizontal > 0) MoveDirection = 1;
            if (LStickHorizontal == 0) MoveDirection = 0;
            if (IsGround == true){
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) jump = true;
            }
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 2")) DethDirector();
        }
    }

    void ActionDirector(){
        rb.velocity = new Vector3(MoveDirection*MoveSpeed,rb.velocity.y,0);
        if (jump) JumpDirector();
        if (CanMove == false){
            LStickHorizontal = 0;
            MoveDirection = 0;
        }
    }

    void Sound(){
        if ((lfjump != jump) && jump == true) NewSoundScriot.Jump1 = true;
        lfjump = jump;
        if (playerstatus == PlayerStatus.Move) NewSoundScriot.Run1 = true;
        else NewSoundScriot.Run1 = false;
        //177
    }

    void JumpDirector(){
        if (JumpTimeLine <= SecondJumpRrocessRange) JumpTimeLine++;
        if (JumpTimeLine <= FirstJumpProcessRange){
            rb.velocity = new Vector3(rb.velocity.x, JumpForce);
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp("joystick button 0")) JumpTimeLine = FirstJumpProcessRange;
            IsGround = false;
        }
        if (JumpTimeLine > FirstJumpProcessRange && JumpTimeLine <= SecondJumpRrocessRange) rb.AddForce(0, JumpKeepForce, 0);
    }

    private void OnCollisionStay(Collision collision){
        if ((collision.gameObject.tag == "Flor") || (collision.gameObject.tag == "iwa")){
            IsGround = true;
            if (JumpTimeLine > FirstJumpProcessRange) { 
                JumpTimeLine = SecondJumpRrocessRange;
                jump = false; 
                JumpTimeLine = 0;
            }
        }
        if ((respawnstack == false) && (collision.gameObject.tag == ("yuka"))){
            FindObjectOfType<PlayerDirector>().StartRespawn();
            DethDirector();
        }

    }

    void latejumptf(){
        ajump = jump;
    }

    void PlayerStatusDirector(){
        if (Hold == false){
            if (MoveDirection == 0) playerstatus = PlayerStatus.Wait;
            if (MoveDirection != 0) playerstatus = PlayerStatus.Move;
            if (ajump == true) playerstatus = PlayerStatus.Jump;
        }
        if (Hold == true){
            if (MoveDirection == 0) playerstatus = PlayerStatus.HoldWait;
            if (MoveDirection != 0) playerstatus = PlayerStatus.HoldMove;
            if (ajump == true) playerstatus = PlayerStatus.HoldJump;
        }
        if (Deth == true) playerstatus = PlayerStatus.Deth;
        if (MoveDirection > 0) PlayerRight = true;
        if (MoveDirection < 0) PlayerRight = false;
    }

    void PlayerAnimationDirector(){
        Animator animator = GetComponent<Animator>();
        int Animaint = animator.GetInteger("panime");
        if (sground != IsGround && IsGround == true) {
            jump4 = true;
            NewSoundScriot.Landing1 = true;
        }
        if (PlayerRight == true){
            if (playerstatus == PlayerStatus.Wait) Animaint = 0;
            if (playerstatus == PlayerStatus.Move) Animaint = 2;
            if (playerstatus == PlayerStatus.Jump){
                if (rb.velocity.y > 0) Animaint = 5;
                if (rb.velocity.y < 0) Animaint = 6;
                if (JumpTimeLine <= FirstJumpProcessRange) Animaint = 4;
                if (jump4 == true) { Animaint = 7; waitanimation = true; AnimationWaiter(1);}
            }
            if (playerstatus == PlayerStatus.HoldWait) Animaint = 12;
            if (playerstatus == PlayerStatus.HoldMove) Animaint = 14;
            if (playerstatus == PlayerStatus.HoldJump){
                if (rb.velocity.y > 0) Animaint = 17;
                if (rb.velocity.y < 0) Animaint = 18;
                if (JumpTimeLine <= FirstJumpProcessRange) Animaint = 16;
                if (jump4 == true) { Animaint = 19; waitanimation = true; AnimationWaiter(1); }
            }
            if (playerstatus == PlayerStatus.Deth) Animaint = 24;
        }
        if (PlayerRight == false){
            if (playerstatus == PlayerStatus.Wait) Animaint = 1;
            if (playerstatus == PlayerStatus.Move) Animaint = 3;
            if (playerstatus == PlayerStatus.Jump){
                if (rb.velocity.y > 0) Animaint = 9;
                if (rb.velocity.y < 0) Animaint = 10;
                if (JumpTimeLine <= FirstJumpProcessRange) Animaint = 8;
                if (jump4 == true) { Animaint = 11; waitanimation = true; AnimationWaiter(1); }
            }
            if (playerstatus == PlayerStatus.HoldWait) Animaint = 13;
            if (playerstatus == PlayerStatus.HoldMove) Animaint = 15;
            if (playerstatus == PlayerStatus.HoldJump){
                if (rb.velocity.y > 0) Animaint = 21;
                if (rb.velocity.y < 0) Animaint = 22;
                if (JumpTimeLine <= FirstJumpProcessRange) Animaint = 20;
                if (jump4 == true) { Animaint = 23; waitanimation = true; AnimationWaiter(1); }
            }
            if (playerstatus == PlayerStatus.Deth) Animaint = 25;
        }
        if (sground == IsGround) jump4 = false;
        sground = IsGround;
        animator.SetInteger("panime", Animaint);
    }

    public void AnimationWaiter(int type){
        if (type == 1) Invoke("WaitF",0.25f);
    }

    void WaitF(){
        waitanimation = false;
    }

    void DethDirector(){
        Deth = true;
        Invoke("PlayerDeth",1f);
        CanMove = false;
    }

    void PlayerDeth(){
        Destroy(this.gameObject);
    }
}
