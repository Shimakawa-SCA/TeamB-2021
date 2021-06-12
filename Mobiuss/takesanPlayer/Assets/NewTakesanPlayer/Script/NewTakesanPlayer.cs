using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTakesanPlayer : MonoBehaviour
{
    SpriteRenderer playersprite;
    public Sprite waitright1;
    public Sprite waitleft1;
    bool a = true;
    // Start is called before the first frame update
    void Start()
    {
        playersprite = GetComponent<SpriteRenderer>();
        Debug.Log(playersprite.sprite);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) a = !a;
        if (a) playersprite.sprite = waitleft1;
        if (!a) playersprite.sprite = waitright1;
    }
}
