using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Damage { get; set; }

    [SerializeField] private float speed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb.velocity = transform.up * speed;
    }
}
