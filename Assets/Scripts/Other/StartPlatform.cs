using UnityEngine;

public class StartPlatform : MonoBehaviour
{
    [field: SerializeField] public Tile ExitToForward { get; private set; }
    [field: SerializeField] public Tile ExitToRight { get; private set; }

    public void OnTileDestroy()
    {
        
    }
}