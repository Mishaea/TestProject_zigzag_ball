using TMPro;
using UnityEngine;
using Zenject;

public class UIScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;

    [Inject] private ScoreManager scoreManager;

    private void OnEnable()
    {
        scoreManager.OnScoreChanged += OnScoreChanged;
        ScoreText.text = scoreManager.Score.ToString();
    }

    private void OnDisable()
    {
        scoreManager.OnScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        ScoreText.text = scoreManager.Score.ToString();
    }
}