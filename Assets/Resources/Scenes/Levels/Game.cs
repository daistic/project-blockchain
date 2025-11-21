using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameplayCanvas gameplayCanvas;
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
        GainMoney();
        gameplayCanvas.CheckFishButtonsAvaiability(money);
    }

    private void GainMoney()
    {
        if (Time.time > nextMoneyTime)
        {
            money += 1;
            gameplayCanvas.UpdateMoneyText(money);
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
        Battlers fishInstance = Instantiate(
           GameManager.instance.battlersBase,
           spawnPos,
           Quaternion.identity,
           playerTower.transform).GetComponent<Battlers>();
        fishInstance.stat = GameManager.instance.fishStats[fishIndex];

        money -= fishInstance.stat.GetPrice();
        gameplayCanvas.UpdateMoneyText(money);
    }
}
