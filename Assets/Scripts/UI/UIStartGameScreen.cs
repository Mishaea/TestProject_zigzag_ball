using UnityEngine;
using Zenject;

public class UIStartGameScreen : MonoBehaviour
{
    [SerializeField] private GameObject Content;

    [Inject] private GameController gameController;

    public void ButtonStartGame()
    {
        Content.SetActive(false);
        gameController.StartGame();
    }
}