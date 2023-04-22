using UnityEngine;

[CreateAssetMenu(fileName = "SpawnCrystalAtEveryStep")]
public class SpawnCrystalAtEveryStep : SpawnCrystalRule
{
    [SerializeField] private int BlockSize = 5;
    [SerializeField] private bool RandomizeCrystalInSection;

    private int blockWithCrystal = 0;
    private int currentBlock;

    public override void OnSpawnTileSection(TileSection tileSection)
    {
        if (currentBlock == blockWithCrystal)
        {
            if (RandomizeCrystalInSection) tileSection.GetRandomTile().SpawnCrystal();
            else tileSection.GetFirstTile().SpawnCrystal();
        }
        currentBlock++;
        if (currentBlock >= BlockSize)
        {
            currentBlock = 0;
            blockWithCrystal = (blockWithCrystal + 1) % BlockSize;
        }
    }

    public override void ResetParams()
    {
        blockWithCrystal = 0;
        currentBlock = 0;
    }
}