using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    public float speed = 8f;
    public float jumpPower = 8f;
    [SerializeField]private Rigidbody2D body;

    void Start()
    {
 
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (verticalInput == 1)
        {
            body.velocity = new Vector2(body.velocity.x, verticalInput * jumpPower);
        }
    }
}
