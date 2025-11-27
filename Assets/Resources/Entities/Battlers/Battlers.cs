using UnityEngine;

public class Battlers : MonoBehaviour
{
    public BattlersStat stat;
    public bool isEnemy;
    public int price;

    [SerializeField] Transform attackPoint;

    private Rigidbody2D rb;
    private float currentHealth;
    private float nextAttackTime;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.layer = LayerMask.NameToLayer(isEnemy ? "Enemy" : "Player");
        currentHealth = stat.GetHealth();
    }

    private void FixedUpdate()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, stat.GetAttackRange(), 0);

        if (hitEnemies.Length > 0)
        {
            rb.linearVelocityX = 0;

            if (Time.time > nextAttackTime)
            {
                foreach (Collider2D enemyCollider in hitEnemies)
                {
                    Battlers battler = enemyCollider.GetComponent<Battlers>();

                    if (battler != null)
                    {
                        battler.TakeDamage(stat.GetDamage());
                    }
                }
                nextAttackTime = Time.time + stat.GetAttackDelay();
            }
        }
        else
        {
            rb.linearVelocityX = stat.GetMoveSpeed() * (isEnemy ? 1 : -1);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }

        print(currentHealth);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireCube(attackPoint.position, new Vector3(stat.GetAttackRange().x, stat.GetAttackRange().y));
    }
}
