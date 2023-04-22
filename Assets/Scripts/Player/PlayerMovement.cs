using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private float MoveSpeed;

    private Vector3 currentDirection;
    private bool isDirectionForward;
    private bool startDirectionInitialized = false;

    [Inject] private GameController gameController;
    [Inject] private MapGenerator mapGenerator;

    private void Update()
    {
        if (gameController.IsGamePaused) return;
        if (!startDirectionInitialized)
        {
            if (PlayerInput.ChangeDirection)
            {
                startDirectionInitialized = true;
                isDirectionForward = mapGenerator.IsFirstTileDirectionForward;
                currentDirection = isDirectionForward ? Vector3.forward : Vector3.right;
            }
        }
        else
        {
            transform.Translate(currentDirection * MoveSpeed, Space.Self);
            if (PlayerInput.ChangeDirection)
            {
                isDirectionForward = !isDirectionForward;
                currentDirection = isDirectionForward ? Vector3.forward : Vector3.right;
            }
        }
    }

    public void ResetParams()
    {
        startDirectionInitialized = false;
        Rigidbody.useGravity = false;
        Rigidbody.isKinematic = true;
        Rigidbody.velocity = Vector3.zero;
    }
}
