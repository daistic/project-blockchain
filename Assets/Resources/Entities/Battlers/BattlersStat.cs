using UnityEngine;

[CreateAssetMenu(fileName = "BattlersStat", menuName = "Scriptable Objects/BattlersStat")]
public class BattlersStat : ScriptableObject
{
    [SerializeField] float health = 5;
    [SerializeField] float damage = 5;
    [SerializeField] Vector2 attackRange = new Vector2(1f, 1f);
    [SerializeField] float attackDelay = 1;
    [SerializeField] float moveSpeed = 2.5f;

    public float GetHealth()
    {
        return health;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetAttackDelay()
    {
        return attackDelay;
    }

    public Vector2 GetAttackRange()
    {
        return attackRange;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
