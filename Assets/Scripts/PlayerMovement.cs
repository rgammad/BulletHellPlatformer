using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5.0f;
    public float minJumpHeight = 2.5f;
    public float maxJumpHeight = 5.0f;
    
    public int maxJumpCount = 2;
    
    private Rigidbody2D rigid;
    private bool jump = false;
    private bool jumpCancel = false;
    private bool isGrounded = false;
    private int jumpCount = 2;
    private bool facingRight = true;

    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
	}
	
	void Update () {
        _MoveInput();
        _JumpInputCheck();
    }
    void FixedUpdate()
    {
        _Jump();
    }

    private void _MoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y);
    }
    private void _JumpInputCheck()
    {
        if (Input.GetButtonDown("Jump") && !jump)
            jump = true;
        if (Input.GetButtonUp("Jump") && !_isGrounded())
            jumpCancel = true;
    }
    private void _Jump()
    {
        if (jump)
        {
            if (jumpCount > 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.velocity += new Vector2(0, maxJumpHeight);
                jumpCount--;
            }
            if (_isGrounded())
                jump = false;
        }
        else
            jumpCount = maxJumpCount;
        if (jumpCancel)
        {
            if(rigid.velocity.y > minJumpHeight)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.velocity += new Vector2(0, minJumpHeight);
            }
            jumpCancel = false;
        }
    }
    private bool _isGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - .55f), Vector2.down);
        if (!ray)
            return false;
        if (ray.collider.CompareTag("Ground") && ray.distance <= 0)
            return true;
        return false;
    }
    
}
