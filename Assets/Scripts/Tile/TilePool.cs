using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    [SerializeField] private Tile TilePrefab;
    [SerializeField] private Transform Container;

    private HashSet<Tile> available = new HashSet<Tile>();

    public Tile GetTile(Vector3 position)
    {
        var instance = available.LastOrDefault();
        if (instance)
        {
            available.Remove(instance);
            instance.transform.position = position;
            instance.gameObject.SetActive(true);
            return instance;
        }
        else
        {
            var newInstance = Instantiate(TilePrefab, position, Quaternion.identity, Container);
            newInstance.SetTilePool(this);
            return newInstance;
        }
    }

    int count;

    public void PutTile(Tile tile)
    {
        if (!tile || available.Contains(tile)) return;
        tile.gameObject.SetActive(false);
        available.Add(tile);
    }
}