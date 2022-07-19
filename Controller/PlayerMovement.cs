using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class PlayerMovement : MonoBehaviour

{
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private DetectInteraction detectLookedAtInteractive;
    
   




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
  
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GetInput();
        Jump();
        Interact();
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (anim.GetBool("Attacking") == true)
            {
                return;
            }
            else if (anim.GetBool("Attacking") == false)
            {
                anim.SetBool("Running", true);
                anim.SetInteger("Condition", 1);

            }

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Running", false);
            anim.SetInteger("Condition", 0);
            Debug.Log("why");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("Jump", 1);
            Debug.Log("yee");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetInteger("Jump", 0);
        }
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("space");
        }




        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void GetInput()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetBool("Running") == true)
            {
                anim.SetBool("Running", false);
                anim.SetInteger("Condition", 0);
            }
            if (anim.GetBool("Running") == false)
            {


                Attacking();
            }
        }

        void Attacking()
        {

                StartCoroutine(AttackRoutine());

        }

        IEnumerator AttackRoutine()
        {
            anim.SetBool("Attacking", true);
            anim.SetInteger("Condition", 2);
            yield return new WaitForSeconds(0.6f);
            anim.SetInteger("Condition", 0);
            anim.SetBool("Attacking", false);
        }
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && detectLookedAtInteractive.lookedAtInteractive !=null)
        {
            Debug.Log("Player pressed the interact button.");
            detectLookedAtInteractive.lookedAtInteractive.InteractWith();
        }
    }


}