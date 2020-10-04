using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 30f;
    public float jumpTime = 0.1f;

    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    private Vector2 screenRes;
    private float objectWidth;
    private float objectHeight;
    private int direction = 1;
    private bool isFacingRight = true;
    public Animator anim;

    private bool isJumping;
    private float currentJumpTime;

    public bool IsJumping { get => isJumping; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenRes = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckJump();
        if (Input.GetButtonDown("Fire1") && !isJumping)
        {
            Jump();
        }

        if (!isJumping)
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            var moveVector = new Vector2(h, v);
            moveVelocity = moveVector.normalized * moveSpeed;
            anim.SetFloat("speedX", Mathf.Abs(h));
            anim.SetFloat("speedY", Mathf.Abs(v));
        }

        CheckMovementDirection();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;

    }

    private void LateUpdate()
    {
        var board = transform.position;
        board.x = Mathf.Clamp(board.x, -screenRes.x + objectWidth, screenRes.x - objectWidth);
        board.y = Mathf.Clamp(board.y, -screenRes.y + objectHeight, screenRes.y - objectHeight);
        transform.position = board;
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && moveVelocity.x < 0)
            Flip();
        else if (!isFacingRight && moveVelocity.x > 0)
            Flip();

    }

    void Flip()
    {
        direction *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void CheckJump()
    {
        if (isJumping)
        {
            currentJumpTime -= Time.deltaTime;
            if (currentJumpTime <= 0)
            {
                isJumping = false;
            }
        }
    }
    void Jump()
    {
        currentJumpTime = jumpTime;
        isJumping = true;
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var heading = mousePos - transform.position;
        moveVelocity = heading.normalized * jumpForce;
    }
}
