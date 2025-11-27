using UnityEngine;

[CreateAssetMenu(fileName = "BattlersStat", menuName = "Scriptable Objects/BattlersStat")]
public class BattlersStat : ScriptableObject
{
    [SerializeField] float health;
    [SerializeField] float damage;
    [SerializeField] Vector2 attackRange;
    [SerializeField] float attackDelay;
    [SerializeField] float moveSpeed;

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
