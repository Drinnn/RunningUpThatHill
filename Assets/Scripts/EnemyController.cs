using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;
    [SerializeField] private float maxHealth;

    private Animator _animator;

    private float _currentHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        UpdateHealthBar();
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        float hpPercent = _currentHealth / maxHealth;
        healthBarFill.fillAmount = hpPercent;
    }

    private void Die()
    {
        _animator.SetBool("IsDead", true);
        Destroy(gameObject, 3f);
    }
}
