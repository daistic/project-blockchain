using UnityEngine;
using TMPro;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;

    public void UpdateMoneyText(int value)
    {
        string text = value.ToString() + "$";
        moneyText.text = text;
    }
    
}
