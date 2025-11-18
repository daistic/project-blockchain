using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] BattlersStat stat;
    [SerializeField] bool isEnemy;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = stat.GetMoveSpeed() * (isEnemy ? 1 : -1);
    }
}
