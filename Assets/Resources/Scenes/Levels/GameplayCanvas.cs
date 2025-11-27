using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] Button[] fishButtons = new Button[4];

    Battlers[] playerFishes;

    private void Start()
    {
        playerFishes = GameManager.instance.playerFishes;
        for (int i = 0; i < fishButtons.Length; i++)
        {
            if (playerFishes[i] == null)
            {
                fishButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void UpdateMoneyText(int money)
    {
        string text = money.ToString();
        moneyText.text = text;
    }
    
    public void CheckFishButtonsAvaiability(int money)
    {
        for (int i = 0; i < fishButtons.Length; i++)
        {
            if (fishButtons[i].gameObject.activeSelf)
            {
                if (playerFishes[i].price > money)
                {
                    fishButtons[i].interactable = false;
                }
                else
                {
                    fishButtons[i].interactable = true;
                }
            }
        }
    }
}
