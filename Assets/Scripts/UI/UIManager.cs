using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIGameOverScreen GameOverScreen;

    public void ShowGameOverScreen()
    {
        GameOverScreen.Show();
    }
}