using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //I should start having some good Documentation but oh well... I'll at least have some funny comments hopefully.
    public Rigidbody2D player;
    public float speed;
    //A perfect solution. Believe me...
    public float sprintSpeed;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("isSprinting", true);
            player.velocity = new Vector2(movement * sprintSpeed * 100 * Time.deltaTime, player.position.y);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("isSprinting", false);
            player.velocity = new Vector2(movement * speed * 100 * Time.deltaTime, player.position.y);
        }
        else
        {
            player.velocity = new Vector2(movement * speed * 100 * Time.deltaTime, player.position.y);
        }
    }

    public void Jump()
    {

    }
}
