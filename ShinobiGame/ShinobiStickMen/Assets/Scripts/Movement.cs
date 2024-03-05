using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("WalkingAndSprintin")]
    //I should start having some good Documentation but oh well... I'll at least have some funny comments hopefully.
    public Rigidbody2D player;
    public float Speed;
    //A perfect solution. Believe me...
    public float sprintSpeed;
    public Animator playerAnimator;
    public float rotationAngle;
    [Header("Jumping")]
    public bool canJump;
    public bool isJumping;
    public bool isGrounded;
    public float jumpSpeed;
    public GameObject feet;
    public float checkRadius;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    //Breakcore hits hard right before realizing your speed needs to be in the thousands
    //Okay not really thousands but you get my point
    public void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        playerAnimator.SetFloat("Speed", movement);


        //I'll regret this later but current me doesn't care
        //3 minutes later I am regreting my decisions even more. I'm sure the if's will work absolutely fine without issue
        //Obviously it doesn't work as it should. oh well the battery's really low so i gotta go :)
        //Hahahahahahah had to completely rework the movement hahahahahahahahahahahhahahahhaahhahahahahahahahhhaahahahah...
        //Okay a new way of movement has been made so hopefully it works now.
        //Eureka it works!! Now I just have to iron out the animations to be smoother and all will be well
        //Forgot About Sprinting...
        //After finally implementing sprinting like it's supposed to be I can move on to jumping.
        if (movement != 0)
        {
            if (movement > 0.01f)
            {
                playerAnimator.SetFloat("Speed", 1f);
                player.transform.eulerAngles = Vector3.up * 0;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerAnimator.SetBool("isSprinting", true);
                    player.velocity = new Vector2(movement * sprintSpeed * 10 * Time.deltaTime, player.position.y);
                }
                else
                {
                    playerAnimator.SetBool("isSprinting", false);
                    player.velocity = new Vector2(movement * Speed * 10 * Time.deltaTime, player.position.y);
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    playerAnimator.SetBool("isSprinting", false);
                }
            }
            if (movement < 0.01f)
            {
                playerAnimator.SetFloat("Speed", 1f);
                player.transform.eulerAngles = Vector3.up * rotationAngle;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    playerAnimator.SetBool("isSprinting", true);
                    player.velocity = new Vector2(movement * sprintSpeed * 10 * Time.deltaTime, player.position.y);
                }
                else 
                {
                    playerAnimator.SetBool("isSprinting", false);
                    player.velocity = new Vector2(movement * Speed * 10 * Time.deltaTime, player.position.y);
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    playerAnimator.SetBool("isSprinting", false);
                }
            }
        }
        if (movement == 0)
        {
            playerAnimator.SetFloat("Speed", 0f);
        }
    }
    //Time to make severe mistakes
    public void Jump()
    {
        if (Physics2D.OverlapCircle(feet.transform.position, checkRadius, ground))
        {
            isGrounded = true;
            canJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            player.velocity = new Vector2(player.position.x, jumpSpeed * Time.deltaTime);
            isJumping = true;
            canJump = false;
            isGrounded = false;
            if (Physics2D.OverlapCircle(feet.transform.position, checkRadius, ground))
            {
                isJumping = false;
                canJump = true;
                isGrounded = true;
            }
        }
    }
}
