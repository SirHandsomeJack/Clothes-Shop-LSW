using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public Animator Animator;

    public float MovementSpeed = 1f;

    public bool IsFacingRight { get; private set; }
    public bool IsFacingUp { get; private set; }
    public bool IsWalking { get; private set; }

    private Vector2 _movement;

    public void Update()
    {
        HandleInput();
    }

    public void FixedUpdate()
    {
        HandleMovement();
    }

    /// <summary>
    /// Gets input from raw axis, normalises movement and set booleans
    /// </summary>
    public virtual void HandleInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement = _movement.normalized;

        IsWalking = Mathf.Abs(_movement.x) > 0f || Mathf.Abs(_movement.y) > 0f;
        if (IsWalking)
        {
            IsFacingRight = _movement.x > 0f;
            IsFacingUp = _movement.y > 0f;
        }
    }

    /// <summary>
    /// Apply movement and set animation parameters
    /// </summary>
    public virtual void HandleMovement()
    {
        if (Rigidbody != null)
            Rigidbody.velocity = _movement * MovementSpeed;

        if (Animator != null)
        {
            Animator.SetFloat("xSpeed", _movement.x);
            Animator.SetFloat("ySpeed", _movement.y);
            Animator.SetBool("FacingRight", IsFacingRight);
            Animator.SetBool("FacingUp", IsFacingUp);
            Animator.SetBool("Walking", IsWalking);
        }
    }
}
