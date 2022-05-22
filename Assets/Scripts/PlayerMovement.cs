using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    // public Animator anim;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    PixelPerfectClamp clamper = new PixelPerfectClamp();

    // live interaction zone switching
    [SerializeField] GameObject interactUp;
    [SerializeField] GameObject interactDown;
    [SerializeField] GameObject interactLeft;
    [SerializeField] GameObject interactRight;

    void Update()
    {
        ProcessInputs();
        Animate();
    }

    void FixedUpdate() {
        Move();
    }

    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && moveDirection.x !=0 || moveDirection.y != 0) {
            lastMoveDirection = moveDirection;
        }

        

        if (moveDirection.x == 1.00) {
            interactUp.SetActive(false);
            interactDown.SetActive(false);
            interactLeft.SetActive(false);
            interactRight.SetActive(true);
        }
        if (moveDirection.x == -1.00) {
            interactUp.SetActive(false);
            interactDown.SetActive(false);
            interactLeft.SetActive(true);
            interactRight.SetActive(false);
        }
        if (moveDirection.y == 1.00) {
            interactUp.SetActive(true);
            interactDown.SetActive(false);
            interactLeft.SetActive(false);
            interactRight.SetActive(false);
        }
        if (moveDirection.y == -1.00) {
            interactUp.SetActive(false);
            interactDown.SetActive(true);
            interactLeft.SetActive(false);
            interactRight.SetActive(false);
        }

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move() {
        // rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 movement =  new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 move = clamper.Clamp(movement * Time.fixedDeltaTime, 8);
        Vector2 oldLocation = clamper.Clamp(rb.position, 8);

        rb.MovePosition(oldLocation + move);
    }

    void Animate() {
        // anim.SetFloat("AnimMoveX", moveDirection.x);
        // anim.SetFloat("AnimMoveY", moveDirection.y);
        // anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
        // anim.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        // anim.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }
}