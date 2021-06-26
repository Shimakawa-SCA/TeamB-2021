using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//タイミング200
public class PlayerDirector : MonoBehaviour
{
    public GameObject Player;
    public GameObject cadaver;
    public GameObject cadaverl;
    public GameObject cadaver3;
    public GameObject cadaverl3;
    public static int RespawnCount;
    public Vector3[] SpawnPoint;
    bool RespawnStack;
    // Start is called before the first frame update
    void Start()
    {
        RespawnCount = 0;
        RespawnStack = false;
        PassInitialize();
        SetPass();
        Invoke("FirstReSpawn",0.1f);

    }

    // Update is called once per frame
    void Update()
    {
        if ((RespawnStack == false) && ((Input.GetKeyDown(KeyCode.R)) || (Input.GetKeyDown("joystick button 2")))){
            StartRespawn();
        }
        SetPass();
    }

    public void StartRespawn(){
        Invoke("PlayerSpawn", 1f);
        Invoke("InsCav", 0.9f);
        RespawnStack = true;
    }

    void FirstReSpawn(){
        RespawnStack = true;
        Instantiate(Player, SpawnPoint[Pass.StageNumber], Quaternion.identity,this.transform);
        Invoke("SpawnDirector", 0.3f);
    }

    void PassInitialize(){
        Pass.RespawnPoint = RespawnCount;
        Pass.RespawnStack = RespawnStack;
    }

    void SetPass(){
        Pass.RespawnPoint = RespawnCount;
        Pass.RespawnStack = RespawnStack;
    }

    void InsCav(){

    }

    void PlayerSpawn(){
        if (Pass.StageNumber == 1 || Pass.StageNumber == 2){
            if (Pass.PlayerRight == true){
                Instantiate(cadaver,Pass.PlayerPosition,Quaternion.identity);
            }
            if (Pass.PlayerRight == false){
                Instantiate(cadaverl, Pass.PlayerPosition, Quaternion.identity);
            }
        }
        if (Pass.StageNumber == 3){
            if (Pass.PlayerRight == true){
                Instantiate(cadaver3, Pass.PlayerPosition, Quaternion.identity);
            }
            if (Pass.PlayerRight == false){
                Instantiate(cadaverl3, Pass.PlayerPosition, Quaternion.identity);
            }
        }
        Instantiate(Player,SpawnPoint[Pass.StageNumber],Quaternion.identity);
        Invoke("SpawnDirector",0.3f);
        RespawnCount++;
    }

    void SpawnDirector(){
        RespawnStack = false;
    }
}
