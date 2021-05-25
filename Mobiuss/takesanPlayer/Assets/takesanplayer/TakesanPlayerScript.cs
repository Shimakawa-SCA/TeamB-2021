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
    bool CanReSpown;
    Vector3 PlayerSpownpoint;

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
        CanReSpown = true;
        PlayerSpownpoint = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
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
        if (LSH != 0)rb.velocity = new Vector3(Speed*MoveDirection,rb.velocity.y,0);
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
        }
    }

    void ReSpown(){
        if (CanReSpown == true){
            if (PlayerRight == true){

                Invoke("RightDeth",0.8f);
            }
            if (PlayerRight == false){

                Invoke("LeftDeth", 0.8f);
            }
        }
    }

    void RightDeth(){
        Instantiate(cadaver,playerposition,q);
        transform.position = PlayerSpownpoint;
        rb.velocity = new Vector3(0, 0, 0);
    }

    void LeftDeth(){
        Instantiate(cadaverl, playerposition, q);
        transform.position = PlayerSpownpoint;
        rb.velocity = new Vector3(0, 0, 0);
    }
}
