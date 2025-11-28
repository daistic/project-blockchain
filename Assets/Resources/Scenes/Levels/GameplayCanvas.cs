using UnityEngine;
using TMPro;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] FishButton[] fishButtons = new FishButton[4];

    Battlers[] playerFishes;

    private void Start()
    {
        playerFishes = GameManager.instance.playerFishes;
        for (int i = 0; i < fishButtons.Length; i++)
        {
            Battlers currentPlayerFish = (playerFishes[i]? playerFishes[i] : null); 

            if (currentPlayerFish == null)
            {
                fishButtons[i].gameObject.SetActive(false);
            }
            else
            {
                if (currentPlayerFish.buttonImage != null)
                {
                    fishButtons[i].ChangeButtonImage(currentPlayerFish.buttonImage);
                }
                fishButtons[i].ChangePriceText(currentPlayerFish.price.ToString());
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
                    fishButtons[i].ChangeButtonInteractibility(false);
                }
                else
                {
                    fishButtons[i].ChangeButtonInteractibility(true);
                }
            }
        }
    }
}
