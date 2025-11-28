using System.Collections;
using UnityEngine;

public class EnemyWaveHandler : MonoBehaviour
{
    [SerializeField] EnemyWave[] waves;
    [SerializeField] float minNextWaveTime = 2.0f;
    [SerializeField] float maxNextWaveTime = 3.5f;

    private void Start()
    {
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minNextWaveTime, maxNextWaveTime);
            yield return new WaitForSeconds(waitTime);

            if (waves.Length == 0) yield break;
            int randomIndex = Random.Range(0, waves.Length);
            EnemyWave currentWave = waves[randomIndex];

            for (int i = 0; i < currentWave.GetEnemiesArray().Length; i++)
            {
                Vector3 spawnPos = new Vector3(
                    transform.position.x,
                    transform.position.y - 2.6f + Random.Range(-0.7f, 0.4f),
                    transform.position.z
                );

                Instantiate(
                    currentWave.GetEnemyAtIndex(i),
                    spawnPos,
                    Quaternion.identity,
                    transform.parent
                );

                float spawnDelay = Random.Range(currentWave.GetMinSpawnTime(), currentWave.GetMaxSpawnTime());
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}