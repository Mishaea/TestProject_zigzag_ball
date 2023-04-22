using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [field: SerializeField] public float Size { get; private set; }
    [SerializeField] private GameObject Crystal;
    [SerializeField] private float DestroyDelay;
    [SerializeField] private float DestroyFallTime;
    [SerializeField] private float DestroyHeight;

    [SerializeField] private StartPlatform startPlatform;

    private TileSection tileSection;
    private TilePool tilePool;

    private void OnEnable()
    {
        if (Crystal) Crystal.SetActive(false);
    }

    private void OnDisable()
    {
        tileSection = null;
        StopAllCoroutines();
    }

    public void SetTileSection(TileSection tileSection) => this.tileSection = tileSection;
    public void SetTilePool(TilePool tilePool) => this.tilePool = tilePool;

    public void SpawnCrystal()
    {
        if (Crystal) Crystal.SetActive(true);
    }

    public void DestroyTile()
    {
        if (tileSection != null)
        {
            StartDestroyAnimation();
        }
        else if (startPlatform)
        {
            startPlatform.OnTileDestroy();
        }
    }

    public void StartDestroyAnimation()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(DestroyDelay);
        float startHeight = transform.position.y;
        float fallTime = DestroyFallTime;
        while (fallTime > 0f)
        {
            fallTime -= Time.deltaTime;
            var position = transform.position;
            position.y = Mathf.Lerp(DestroyHeight, startHeight, fallTime / DestroyFallTime);
            transform.position = position;
            yield return null;
        }
        tileSection.OnTileDestroy(this);
        if (tilePool)
        {
            tilePool.PutTile(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
