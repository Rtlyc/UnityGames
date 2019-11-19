using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesWalker : MonoBehaviour
{
    private float speed = 2.0f;
    Rigidbody2D rigidbody2d;
    Animator animator;
    public bool vertical;
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;
    bool broken = true;
    public ParticleSystem Mysmoke; 
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;
        }
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            position.y += direction * Time.deltaTime * speed;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x += direction * Time.deltaTime * speed;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        RubyController rubyController = collision.gameObject.GetComponent<RubyController>();
        if(rubyController != null)
        {
            rubyController.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
        Mysmoke.Stop();
        Destroy(Mysmoke);
    }
}
