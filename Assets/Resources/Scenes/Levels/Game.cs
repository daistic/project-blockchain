using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameplayCanvas canvas;
    [SerializeField] float moneyDelay = 1f;
    [SerializeField] Tower playerTower;
    
    int money = 0;
    float nextMoneyTime;

    private void Start()
    {
        nextMoneyTime = Time.time + moneyDelay;
    }

    private void Update()
    {
        if (Time.time > nextMoneyTime)
        {
            money += 1;
            canvas.UpdateMoneyText(money);

            nextMoneyTime = Time.time + moneyDelay;
        }
    }

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
