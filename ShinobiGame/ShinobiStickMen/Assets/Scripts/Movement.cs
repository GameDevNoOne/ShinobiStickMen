using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //I should start having some good Documentation but oh well... I'll at least have some funny comments hopefully.
    public Rigidbody2D player;
    public float speed;
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
    public void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal");

        player.velocity = new Vector2(movement * speed * Time.deltaTime, player.position.y);
    }
}
