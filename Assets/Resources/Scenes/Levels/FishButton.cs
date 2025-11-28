using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image buttonImage;
    [SerializeField] TextMeshProUGUI priceText;

    public void ChangeButtonInteractibility(bool interactibility)
    {
        button.interactable = interactibility;
    }

    public void ChangeButtonImage(Sprite newImage)
    {
        buttonImage.sprite = newImage;
    }

    public void ChangePriceText(string newPriceText)
    {
        priceText.text = newPriceText;
    }
}
