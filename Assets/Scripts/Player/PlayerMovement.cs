using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator anim;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    private bool isMovementSuspended = false;
    PixelPerfectClamp clamper = new PixelPerfectClamp();

    [Header("Interaction Zones")]
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
        if (!DialogCanvas.Instance.IsDialogShowing() && !isMovementSuspended) {
            Move();
        }
    }

    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && moveDirection.x !=0 || moveDirection.y != 0) {
            lastMoveDirection = moveDirection;
        }       

        if (!DialogCanvas.Instance.IsDialogShowing() && !isMovementSuspended) {
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
        }

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move() {
        // rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 movement =  new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 move = clamper.Clamp(movement * Time.fixedDeltaTime, 16);
        Vector2 oldLocation = clamper.Clamp(rb.position, 16);

        rb.MovePosition(oldLocation + move);
    }

    void Animate() {
        if (!DialogCanvas.Instance.IsDialogShowing() && !isMovementSuspended) {
            anim.SetFloat("MoveX", moveDirection.x);
            anim.SetFloat("MoveY", moveDirection.y);
            anim.SetFloat("MoveMagnitude", moveDirection.magnitude);
            anim.SetFloat("LastMoveX", lastMoveDirection.x);
            anim.SetFloat("LastMoveY", lastMoveDirection.y);
        } else {
            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", 0);
            anim.SetFloat("MoveMagnitude", 0);
        }
    }

    public void PushUpwards()
    {
        rb.position =  new Vector2(rb.position.x, rb.position.y + 2);
    }

    public void SetElectrocution(bool isBeingElectrocuted)
    {
        anim.SetBool("isBeingElectrocuted", isBeingElectrocuted);
    }

    public void SetSuspendMovement(bool isSuspended)
    {
        isMovementSuspended = isSuspended;
        anim.SetFloat("LastMoveX", 0);
        anim.SetFloat("LastMoveY", -1.0f);
    }
}