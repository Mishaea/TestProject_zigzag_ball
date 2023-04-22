using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Tile TilePrefab;
    [SerializeField] private SpawnCrystalRule SpawnCrystalRule;
    [SerializeField] private int MinTileCount = 30;
    [SerializeField, Range(1, 3)] private int RoadWidth = 1;

    private Tile lastTile;
    private bool isNextDirectionForward;
    private int currentTileCount;
    private HashSet<Tile> allSpawnedTile = new HashSet<Tile>();

    public bool IsFirstTileDirectionForward { get; private set; }

    [Inject] private GameController gameController;
    [Inject] private StartPlatform startPlatform;
    [Inject] private TilePool tilePool;

    private void OnEnable()
    {
        ResetParams();
    }

    private void Update()
    {
        if (gameController.IsGamePaused) return;
        if (currentTileCount < MinTileCount)
        {
            for (int i = 0; i < MinTileCount - currentTileCount; i++)
            {
                SpawnTileSection();
            }
            currentTileCount = MinTileCount;
        }
    }

    public void OnTileDestroy()
    {
        currentTileCount--;
    }

    private void SpawnTileSection()
    {
        if (lastTile == null)
        {
            var isForward = Random.value >= 0.5f;
            if (isForward) lastTile = startPlatform.ExitToForward;
            else lastTile = startPlatform.ExitToRight;
            isNextDirectionForward = isForward;
            IsFirstTileDirectionForward = isForward;
        }
        var direction = isNextDirectionForward ? Vector3.forward : Vector3.right;
        var roadWidthDirection = isNextDirectionForward ? Vector3.right : Vector3.forward;
        var isLastDirectionForward = isNextDirectionForward;
        isNextDirectionForward = Random.value >= 0.5f;

        var position = lastTile.transform.position + direction * TilePrefab.Size;
        var newTile = tilePool.GetTile(position);

        var sectionTiles = new List<Tile>();
        sectionTiles.Add(newTile);

        for (int j = 1; j < RoadWidth; j++)
        {
            newTile = tilePool.GetTile(position + roadWidthDirection * TilePrefab.Size * j);
            sectionTiles.Add(newTile);
        }

        var tileSection = new TileSection(this, sectionTiles.ToArray());
        foreach (var item in sectionTiles)
        {
            item.SetTileSection(tileSection);
            allSpawnedTile.Add(item);
        }

        if (isLastDirectionForward != isNextDirectionForward)
        {
            lastTile = sectionTiles.Last();
        }
        else
        {
            lastTile = sectionTiles.First();
        }

        SpawnCrystalRule.OnSpawnTileSection(tileSection);
    }

    public void ResetParams()
    {
        SpawnCrystalRule.ResetParams();
        lastTile = null;
        isNextDirectionForward = false;
        currentTileCount = 0;
        foreach (var item in allSpawnedTile)
        {
            if (item) tilePool.PutTile(item);
        }
        allSpawnedTile.Clear();
    }
}
