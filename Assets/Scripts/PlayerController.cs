using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private WeaponSystem weaponSystem;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rb;
    private Animator _animator;

    private bool _canMove = true;
    private Vector2 _movementDirection;
    private Vector2 _mousePosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        instance = this;
    }

    private void Update()
    {
        if (_canMove && !GameManager.instance.IsPaused)
        {
            GetInput();
            Animate();
            if (Input.GetButton("Fire1"))
            {
                weaponSystem.CurrentWeapon.Shoot();
            }
        }
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
        _movementDirection.Normalize();

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

    private void Animate()
    {
        if (_movementDirection != Vector2.zero)
        {
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }

    public void Die()
    {
        _animator.SetBool("IsDead", true);
        _canMove = false;
    }
}
