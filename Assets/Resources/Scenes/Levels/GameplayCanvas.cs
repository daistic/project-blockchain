using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] float moneyDelay = 1f;

    [SerializeField] GameObject[] fishButtons = new GameObject[5];

    int money = 0;
    float nextMoneyTime;
    BattlersStat[] playerFishes;

    private void Start()
    {
        nextMoneyTime = Time.time + moneyDelay;

        playerFishes = GameManager.instance.playerFishes;
        for (int i = 0; i < fishButtons.Length; i++)
        {
            if (playerFishes[i] == null)
            {
                fishButtons[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        UpdateMoneyText();
        CheckFishButtonsAvaiability();
    }

    private void UpdateMoneyText()
    {
        if (Time.time > nextMoneyTime)
        {
            money += 1;
            nextMoneyTime = Time.time + moneyDelay;
        }

        string text = money.ToString() + "$";
        moneyText.text = text;
    }
    
    private void CheckFishButtonsAvaiability()
    {
        for (int i = 0; i < fishButtons.Length; i++)
        {
            if (fishButtons[i].activeSelf)
            {
                Button button = fishButtons[i].GetComponent<Button>();
                if (playerFishes[i].GetPrice() > money)
                { 
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
            }
        }
    }
}
