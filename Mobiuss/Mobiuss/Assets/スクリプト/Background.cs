using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float borderLine;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(0.001f, 0, 0);

        // 境界線を超えたら
        if (transform.position.x < borderLine)
        {
            // 最初に位置に戻す
            transform.position = startPos;
        }
    }
}