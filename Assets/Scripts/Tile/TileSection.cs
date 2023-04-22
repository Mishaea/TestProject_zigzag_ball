
using System.Linq;
using UnityEngine;

public class TileSection
{
    private MapGenerator mapGenerator;
    private Tile[] tiles;

    public TileSection(MapGenerator mapGenerator, Tile[] tiles)
    {
        this.mapGenerator = mapGenerator;
        this.tiles = tiles;
    }

    public Tile GetFirstTile() => tiles.FirstOrDefault();
    public Tile GetRandomTile() => tiles[Random.Range(0, tiles.Length)];

    public void OnTileDestroy(Tile tile)
    {
        if (mapGenerator) mapGenerator.OnTileDestroy();
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] == tile)
            {
                tiles[i] = null;
                continue;
            }
            if (tiles[i]) tiles[i].StartDestroyAnimation();
        }
    }
}