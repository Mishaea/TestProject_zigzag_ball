using UnityEngine;

public abstract class SpawnCrystalRule : ScriptableObject
{
    public abstract void OnSpawnTileSection(TileSection tileSection);
    public abstract void ResetParams();
}