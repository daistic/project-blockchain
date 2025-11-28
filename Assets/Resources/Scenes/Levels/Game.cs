using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] GameplayCanvas gameplayCanvas;
    [SerializeField] GameOverCanvas gameoverCanvas;
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

    public void SpawnFish(int fishIndex)
    {
        Vector3 spawnPos = new Vector3(
            playerTower.transform.position.x,
            playerTower.transform.position.y - 1.5f + Random.Range(-0.7f, 0.4f),
            playerTower.transform.position.z
        );
        Battlers fishInstance = Instantiate(
            GameManager.instance.playerFishes[fishIndex],
            spawnPos,
            Quaternion.identity,
            playerTower.transform
        );

        money -= fishInstance.price;
        gameplayCanvas.UpdateMoneyText(money);
    }

    public void OnGameOverEvent(bool playerWin)
    {
        gameplayCanvas.gameObject.SetActive(false);

        gameoverCanvas.gameObject.SetActive(true);
        gameoverCanvas.DisplayGameOverText(playerWin);
    }

    public void OnReplayButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
