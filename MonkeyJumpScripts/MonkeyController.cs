using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MonkeyController : MonoBehaviour
{
    Rigidbody2D body;
    PlayerData playerdata;
    public FixedJoystick joystick;
    private bool isDead = false;
    private float Normalpush = 10f;
    private float Extrapush = 20f;
    public float xvelocity = 2f;
    public float maxheight = 0f;
    private float maxhistory;
    private int count = 0;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        try
        {
            playerdata = SaveSystem.LoadPlayer();
            maxhistory = playerdata.highest_score;
            GameController.instance.Display_History(maxhistory);
        }
        catch(System.Exception e)
        {
            GameController.instance.Display_History(0);
        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (isDead) return;
        if(target.tag == "Falldown" || target.tag == "Bird")
        {
            SoundManager.instance.GameOverSound();
            isDead = true;
            if(maxheight > maxhistory)
            {
                SaveSystem.SavePlayer(this);
            }
            GameController.instance.RestartGame();
            return;
        }
        if(target.tag == "Bananas")
        {
            SoundManager.instance.ExtraJumpSound();
            body.velocity = new Vector2(body.velocity.x, Extrapush);
            target.gameObject.SetActive(false);
            count++;
            //soundcontroller
        }else if(target.tag == "OneBanana")
        {
            SoundManager.instance.JumpSound();
            body.velocity = new Vector2(body.velocity.x, Normalpush);
            target.gameObject.SetActive(false);
            count++;
            //soundcontroller
        }
        if(count > 2)
        {
            count = 0;
            SpawnerController.instance.CreatePlatform();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchposition = Camera.main.ScreenToWorldPoint(touch.position);
            if(touchposition.x > 0)
            {
                body.velocity = new Vector2(xvelocity, body.velocity.y);
            }else if(touchposition.x < 0)
            {
                body.velocity = new Vector2(-xvelocity, body.velocity.y);
            }
        }

        //if(joystick.Horizontal > 0.2f)
        //{
        //    body.velocity = new Vector2(xvelocity, body.velocity.y);
        //}
        //else if (joystick.Horizontal < -0.2f)
        //{
        //    body.velocity = new Vector2(-xvelocity, body.velocity.y);
        //}
        float current = body.transform.position.y;
        if(current > maxheight)
        {
            GameController.instance.Display(current);
            maxheight = current;
        }

    }


}
