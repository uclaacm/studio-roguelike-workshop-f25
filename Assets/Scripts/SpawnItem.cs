using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] ItemPoolSO itemPool;
    [SerializeField] Transform lowerLeft;
    [SerializeField] Transform upperRight;
    [SerializeField] int numItemsToSpawn;

    

    void Start()
    {
        if (itemPool == null || lowerLeft == null || upperRight == null) 
        {
            Debug.Log("null variable - check serialized fields");
            return;
        } 

        lowerLeft.position = new Vector2(-16, 13);
        float minX = lowerLeft.position.x;
        float maxX = upperRight.position.x;
        float minY = lowerLeft.position.y;
        float maxY = upperRight.position.y;

        if (itemPool.items[0] != null)
        {
            for (int i = 0; i < numItemsToSpawn; i++)
            {
                var itemSO = itemPool.items[Random.Range(0, itemPool.items.Count)];

                GameObject prefab = itemSO.pickupPrefab;

                Vector2 spawnPos = new Vector2(minX, minY);

                Instantiate(prefab, spawnPos, Quaternion.identity);
            }
        }
    }

}
