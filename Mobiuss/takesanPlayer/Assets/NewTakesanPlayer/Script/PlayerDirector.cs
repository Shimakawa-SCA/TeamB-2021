using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirector : MonoBehaviour
{
    public GameObject Player;
    int RespawnCount;
    public Vector3[] SpawnPoint;
    bool RespawnStack;
    // Start is called before the first frame update
    void Start()
    {
        RespawnCount = 0;
        RespawnStack = false;
        PassInitialize();
        SetPass();
        Invoke("PlayerSpawn",0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((RespawnStack == false) && (Input.GetKeyDown(KeyCode.R))){
            PlayerSpawn();
        }
    }

    void PassInitialize(){
        Pass.RespawnPoint = RespawnCount;
        Pass.RespawnStack = RespawnStack;
    }

    void SetPass(){
        Pass.RespawnPoint = RespawnCount;
        Pass.RespawnStack = RespawnStack;
    }

    void PlayerSpawn(){
        RespawnStack = true;
        Instantiate(Player,SpawnPoint[Pass.StageNumber],Quaternion.identity);
        Invoke("SpoawnDirector",1.2f);
    }

    void SpawnDirector(){
        RespawnStack = false;
    }
}
