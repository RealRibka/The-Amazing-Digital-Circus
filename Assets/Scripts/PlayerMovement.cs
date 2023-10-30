using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isGrounded;

    private Animator animator; // Добавьте ссылку на компонент Animator

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Инициализируйте компонент Animator
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        if (isGrounded)
        {
            moveDirection = transform.TransformDirection(new Vector3(horizontal, 0, vertical));
            moveDirection *= moveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                animator.SetBool("IsJumping", true); // Анимация прыжка
            }
            else if (horizontal != 0 || vertical != 0) // Если есть движение
            {
                if (moveSpeed == runSpeed)
                    animator.SetBool("IsRunning", true); // Анимация бега
                else
                    animator.SetBool("IsWalking", true); // Анимация ходьбы
            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsJumping", false); // Анимация покоя
            }
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}