using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    private Vector2 screenRes;
    private float objectWidth;
    private float objectHeight;
    private int direction = 1;
    private bool isFacingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenRes = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var moveVector = new Vector2(h, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveVector.normalized * moveSpeed;

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
}
