using System.Collections;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float gravity = -19.62f;

    [SerializeField] private float dashSpeed = 18f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1.5f;

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;
    private bool isDashing = false;
    private float lastDashTime = -999f;

    protected override void Start()
    {
        base.Start();
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        GameManager.Instance?.UpdateHealthUI(Hp, MaxHp);
    }

    private void Update()
    {
        if (Hp <= 0 || isDashing) return;

        ApplyGravity();

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        Movement(moveDirection);
        Turn(moveDirection);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown)
        {
            Vector3 dashDir = moveDirection != Vector3.zero ? moveDirection : transform.forward;
            StartCoroutine(PerformDash(dashDir));
        }
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Movement(Vector3 moveDirection)
    {
        controller.Move(moveDirection * movementSpeed * Time.deltaTime);

        if (animator != null)
        {
            animator.SetFloat("MoveSpeed", moveDirection.magnitude);
        }
    }

    public void Turn(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private IEnumerator PerformDash(Vector3 direction)
    {
        isDashing = true;
        lastDashTime = Time.time;
        transform.forward = direction;

        float elapsed = 0f;
        while (elapsed < dashDuration)
        {
            elapsed += Time.deltaTime;
            controller.Move(direction * dashSpeed * Time.deltaTime);
            yield return null;
        }

        isDashing = false;
    }

    public override void TakeDamage(int damage, Character attacker)
    {
        if (isDashing) return;

        base.TakeDamage(damage, attacker);
        GameManager.Instance?.UpdateHealthUI(Hp, MaxHp);

        if (Hp > 0 && animator != null)
        {
            animator.SetTrigger("Hit");
        }
    }

    public override void Die(Character attacker)
    {
        if (animator != null)
        {
            animator.SetBool("isDead", true);
        }
        this.enabled = false;
    }
}