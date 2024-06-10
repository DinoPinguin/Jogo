using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public bool isJumping;
    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move() 
    {
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new UnityEngine.Vector2(movement * Speed, rig.velocity.y);

        if(movement > 0f)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
              if(movement < 0f)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
              if(movement == 0)
        {
            anim.SetBool("Walk", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            rig.AddForce(new UnityEngine.Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8) 
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }

        if(collision.gameObject.tag == "Espinho") 
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Finish") 
        {
            GameController.instance.ShowGameWin();
            Destroy(gameObject);
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8) 
        {
            isJumping = true;
        }
    }
}
            