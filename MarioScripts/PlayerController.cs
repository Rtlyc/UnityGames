using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform groundcheck;
    public float checkradius;
    public LayerMask mask;
    public Animator animator;
    public Rigidbody2D controller;

    public float runSpeed = 5f;
    float horizontalMove = 0f;
    bool forward = true;
    public float JumpForce = 500f;

    private bool onground;

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.transform.tag == "Enemies")
        {
            Debug.Log("DeathArrived");
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && onground)
        {
            Jump();
            animator.SetBool("Jump", true);
            onground = false;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(horizontalMove > 0 && !forward)
        {
            Flip();
        }else if(horizontalMove < 0 && forward)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        onground = Physics2D.OverlapCircle(groundcheck.position, checkradius, mask);
        if (onground)
        {
            animator.SetBool("Jump", false);
        }
        Vector2 velocity = new Vector2(horizontalMove, controller.velocity.y);
        controller.velocity = velocity;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }

    void Flip()
    {
        forward = !forward;
        Vector3 place = transform.localScale;
        place.x *= -1;
        transform.localScale = place;
    }

    void Jump()
    {
        controller.AddForce(new Vector2(0f, JumpForce));
    }

}
