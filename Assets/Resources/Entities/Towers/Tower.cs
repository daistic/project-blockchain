using UnityEngine;

public class Tower : MonoBehaviour, IDamageable
{
    public float health = 100f;
    public bool isEnemy;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            print("win game");
        }

        print(health);
    }
}
