using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameplayCanvas canvas;
    [SerializeField] float moneyDelay = 1f;
    
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
}
