using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnCrystalRandomInBlock")]
public class SpawnCrystalRandomInBlock : SpawnCrystalRule
{
    [SerializeField] private int BlockSize = 5;
    [SerializeField] private bool RandomizeCrystalInSection;

    private List<TileSection> tileSections = new List<TileSection>();

    public override void OnSpawnTileSection(TileSection tileSection)
    {
        tileSections.Add(tileSection);
        if (tileSections.Count == BlockSize)
        {
            var crystalTileSection = tileSections[Random.Range(0, tileSections.Count)];
            if (RandomizeCrystalInSection) crystalTileSection.GetRandomTile().SpawnCrystal();
            else crystalTileSection.GetFirstTile().SpawnCrystal();
            tileSections.Clear();
        }
    }

    public override void ResetParams()
    {
        tileSections.Clear();
    }
}