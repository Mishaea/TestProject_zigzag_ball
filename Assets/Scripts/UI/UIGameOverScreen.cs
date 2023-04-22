using TMPro;
using UnityEngine;
using Zenject;

public class UIGameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject Content;
    [SerializeField] private TextMeshProUGUI ScoreText;

    [Inject] private GameController gameController;
    [Inject] private ScoreManager scoreManager;

    public void Show()
    {
        ScoreText.text = scoreManager.Score.ToString();
        Content.SetActive(true);
    }

    public void ButtonStartGame()
    {
        Content.SetActive(false);
        gameController.StartGame();
    }
}