using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    public bool isEnemy;

    [SerializeField] TextMeshPro healthText;

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
            print("win game");
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
