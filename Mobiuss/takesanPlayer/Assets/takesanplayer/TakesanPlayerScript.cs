using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakesanPlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public static Vector3 playerposition;
    float blx;
    float LSH;
    float MoveDirection;
    public float Speed;
    public static bool PlayerRight;

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
    int repoint;
    Vector3 PlayerSpownpoint;

    public static bool Hold;
    bool PlayerDeth;
    bool Wait;

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
        PlayerSpownpoint = new Vector3(0,0,0);
        Hold = false;
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
            if (Input.GetKeyDown(KeyCode.Space)) DoJump = true;
            //if (Input.GetButtonDown(""))
            if (Input.GetKeyDown(KeyCode.R)) ReSpown();
        }
        AddSpeed();
        if (DoJump  == true) Jump();
        Playerdirection();
        JumpStatus();
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
        }
    }

    void Jump() { 
        if (JumpTimeLine <= SecondJumpRrocessRange) JumpTimeLine++;
        if (JumpTimeLine <= FirstJumpProcessRange) FirstJumpProcess();
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
        if (JumpVelocityy == JumpForce) JumpStatusNumber = 1;
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
        Debug.Log(JumpStatusNumber);
    }

    private void OnCollisionStay(Collision collision){
        if (collision.gameObject.tag == ("Flor")){
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
            Invoke("RightDeth", 0.8f);
        }
        if (PlayerRight == false){
            Invoke("LeftDeth", 0.8f);
        }
        CanMove = false;
        PlayerDeth = true;
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
        CanMove = true;
    }

    void GetPlayerStatus(){
        Animator animator = GetComponent<Animator>();
        int Animaint = animator.GetInteger("Animationint");
        if (LSH == 0) Wait = true;
        if (Hold == true){
            if (DoJump == true){
                if (JumpStatusNumber == 1){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
                if (JumpStatusNumber == 2){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
                if (JumpStatusNumber == 3){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
                if (JumpStatusNumber == 4){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
            }
            if (DoJump == false){
                if (Wait == true){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
                if (Wait == false){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
            }
        }
        if (Hold == false){
            if (DoJump == true)
            {
                if (JumpStatusNumber == 1)
                {
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
                if (JumpStatusNumber == 2){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
                if (JumpStatusNumber == 3){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
                if (JumpStatusNumber == 4){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
            }
            if (DoJump == false){
                if (Wait == true){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
                if (Wait == false){
                    if (PlayerRight == true){

                    }
                    if (PlayerRight == false){

                    }
                }
            }
        }
        if (PlayerDeth == true){
            if (PlayerRight == true){

            }
            if (PlayerRight == false){

            }
        }
        animator.SetInteger("Animationint", Animaint);
    }
}
