using UnityEngine;
using Zenject;

public class PlayerCrystalChecker : MonoBehaviour
{
    [Inject] private ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);

        scoreManager.OnTakeCrystal();
    }
}