using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{ // aqui são as variaveis 
    public float Speed; //controla velocidade do personagem
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start() // apenas private
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //checa todo momento
        Jump();
    }
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); 
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f); // eulerAngles permite rotacionar 
        }
         if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f); // rotaciona para esquerda
        }
         if(Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("walk", false);
        }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping) //verificando se o valor é true or false
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }   
    void OnCollisionEnter2D(Collision2D collision) // player toca no chão e para de pular
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }
    void OnCollisionExit2D(Collision2D collision) // detecta quando o player não toca em nada
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
