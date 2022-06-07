using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;
    [SerializeField] private float maxHealth;

    private float _currentHealth;

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
            PlayerController.instance.Die();
        }
    }

    private void UpdateHealthBar()
    {
        float hpPercent = _currentHealth / maxHealth;
        healthBarFill.fillAmount = hpPercent;
    }
}
