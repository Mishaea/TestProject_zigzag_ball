using UnityEngine;
using Zenject;

public class PlayerGroundCheker : MonoBehaviour
{
    [SerializeField] private Rigidbody Rigidbody;

    private int GroundTileCount;

    [Inject] private GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        GroundTileCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        GroundTileCount--;
        if (GroundTileCount <= 0)
        {
            Rigidbody.useGravity = true;
            Rigidbody.isKinematic = false;

            gameController.GameOver();
        }
        other.GetComponentInParent<Tile>()?.DestroyTile();
    }
}