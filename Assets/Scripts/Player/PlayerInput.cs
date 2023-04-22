using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
    public bool ChangeDirection { get; private set; }

    [Inject] private GameController gameController;

    private void Update()
    {
        if (gameController.IsGamePaused) return;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChangeDirection = true;
        }
        else
        {
            ChangeDirection = false;
        }
    }
}
