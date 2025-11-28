using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    public bool isEnemy;

    [SerializeField] TextMeshPro healthText;
    [SerializeField] UnityEvent gameOverEvent;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthText();

        if (currentHealth < 0)
        {
            gameOverEvent.Invoke();
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
