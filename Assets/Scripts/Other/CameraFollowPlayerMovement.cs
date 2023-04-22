using UnityEngine;
using Zenject;

public class CameraFollowPlayerMovement : MonoBehaviour
{
    [SerializeField] private float FollowSpeed = 1f;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float MinHeight;

    [Inject] private GameController gameController;
    [Inject] private PlayerMovement playerMovement;

    private void Update()
    {
        if (gameController.IsGamePaused) return;
        if (playerMovement == null) return;
        var targetPosition = playerMovement.transform.position + Offset;
        if (targetPosition.y < MinHeight)
        {
            playerMovement = null;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * FollowSpeed);
    }
}
