using TMPro;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI loseText;

    public void DisplayGameOverText(bool playerWin)
    {
        winText.gameObject.SetActive(playerWin);
        loseText.gameObject.SetActive(!playerWin);
    }
}
