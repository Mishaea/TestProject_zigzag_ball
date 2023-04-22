using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int> OnScoreChanged;

    public int Score { get; private set; }

    public void OnTakeCrystal()
    {
        Score++;
        OnScoreChanged?.Invoke(Score);
    }

    public void ResetParams()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score);
    }
}