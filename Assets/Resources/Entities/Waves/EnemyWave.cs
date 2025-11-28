using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "Scriptable Objects/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    [SerializeField] GameObject[] enemies = new GameObject[0];
    [SerializeField] float minSpawnTime = 0.5f;
    [SerializeField] float maxSpawnTime = 1.0f;

    public GameObject[] GetEnemiesArray()
    {
        return enemies;
    }

    public GameObject GetEnemyAtIndex(int index)
    {
        return enemies[index];
    }

    public float GetMinSpawnTime()
    {
        return minSpawnTime;
    }

    public float GetMaxSpawnTime()
    {
        return maxSpawnTime;
    }
}
