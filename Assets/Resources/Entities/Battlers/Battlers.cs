using UnityEngine;

public class Battlers : MonoBehaviour
{
    public BattlersStat stat;
    public bool isEnemy;
    public int price;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.layer = LayerMask.NameToLayer(isEnemy ? "Enemy" : "Player");
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = stat.GetMoveSpeed() * (isEnemy ? 1 : -1);
    }
}
