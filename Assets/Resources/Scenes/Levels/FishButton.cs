using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image buttonImage;
    [SerializeField] TextMeshProUGUI priceText;

    public void changeButtonInteractibility(bool interactibility)
    {
        button.interactable = interactibility;
    }

    public void changeButtonImage(Sprite newImage)
    {
        buttonImage.sprite = newImage;
    }

    public void changePriceText(string newPriceText)
    {
        priceText.text = newPriceText;
    }
}
