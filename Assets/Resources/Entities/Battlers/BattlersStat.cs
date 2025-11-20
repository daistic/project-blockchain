using UnityEngine;

[CreateAssetMenu(fileName = "BattlersStat", menuName = "Scriptable Objects/BattlersStat")]
public class BattlersStat : ScriptableObject
{
    [SerializeField] float health;
    [SerializeField] float attack;
    [SerializeField] float moveSpeed;
    [SerializeField] int price;

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetPrice()
    {
        return price;
    }
}
