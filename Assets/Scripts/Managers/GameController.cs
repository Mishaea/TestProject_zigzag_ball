using System;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public bool IsGamePaused { get; private set; } = true;

    [SerializeField] private Transform PlayerSpawnPoint;

    [Inject] private PlayerMovement playerMovement;
    [Inject] private PlayerInput playerInput;
    [Inject] private UIManager uiManager;
    [Inject] private MapGenerator mapGenerator;
    [Inject] private ScoreManager scoreManager;

    public void StartGame()
    {
        mapGenerator.ResetParams();
        scoreManager.ResetParams();
        playerMovement.ResetParams();
        playerMovement.transform.position = PlayerSpawnPoint.position;
        playerMovement.transform.rotation = Quaternion.identity;
        playerMovement.enabled = true;
        playerInput.enabled = true;
        IsGamePaused = false;
    }

    public void GameOver()
    {
        IsGamePaused = true;
        playerMovement.enabled = false;
        playerInput.enabled = false;
        uiManager.ShowGameOverScreen();
    }
}