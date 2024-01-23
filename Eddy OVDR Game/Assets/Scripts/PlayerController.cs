using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    public float speed = 8f;
    public float jumpPower = 8f;
    private bool facingRight;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        FlipLogic();
        Animate();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        Vector2 playerInput = new Vector2(horizontalInput, verticalInput);
        Vector2 moveForce = playerInput * speed;
        body.velocity = moveForce;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;
        player.transform.Rotate(0, 180, 0);
    }

    private void FlipLogic()
    {
        if (horizontalInput > 0f && !facingRight)
        {
            //If we're moving right but not facing right, flip the sprite and set     facingRight to true.
            Flip();
            facingRight = true;
        }
        else if (horizontalInput < 0f && facingRight)
        {
            //If we're moving left but not facing left, flip the sprite and set facingRight to false.
            Flip();
            facingRight = false;
        }
    }

    private void Animate()
    {
        if (horizontalInput != 0)
        {
            anim.SetBool("HorizontalMove", true);
        }
        else
        {
            anim.SetBool("HorizontalMove", false);
        }
    }
}
