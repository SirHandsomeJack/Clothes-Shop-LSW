using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MovementSpeed = 1f;

    public Rigidbody2D Rigidbody;
    public Animator Animator;

    private Vector2 _movement;

    public void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement = _movement.normalized;
    }

    public void FixedUpdate()
    {
        Rigidbody.velocity = _movement * MovementSpeed;
    }
}
