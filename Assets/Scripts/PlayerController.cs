using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rb;

    private Vector2 _movementDirection;
    private Vector2 _mousePosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void GetInput()
    {
        _movementDirection.x = Input.GetAxisRaw("Horizontal");
        _movementDirection.y = Input.GetAxisRaw("Vertical");

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move()
    {
        _rb.MovePosition(_rb.position + _movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        Vector2 direction = _mousePosition - _rb.position;
        transform.up = direction;
    }
}
