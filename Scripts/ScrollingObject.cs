﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameController.instance.scrollspeed, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gameover == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
