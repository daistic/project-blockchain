using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameplayCanvas canvas;
    [SerializeField] Tower playerTower;

    public void spawnFish(int fishIndex)
    {
        Vector3 spawnPos = new Vector3(
            playerTower.transform.position.x,
            playerTower.transform.position.y + Random.Range(-1.5f, 1.5f),
            playerTower.transform.position.z
        );
        Instantiate(GameManager.instance.playerFishes[fishIndex], spawnPos, Quaternion.identity, playerTower.transform);
    }
}
