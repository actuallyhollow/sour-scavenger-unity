using UnityEngine;
using System.Collections.Generic;

public class ConsumableSpawner : MonoBehaviour
{
    [Header("Item Prefabs")]
    [SerializeField] private GameObject[] itemPrefabs;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 3.0F;
    [SerializeField] private float spawnRadius = 20.0F; 
    [SerializeField] private float spawnHeight = 0.0F;
    [SerializeField] private int maxItems = 15;
    [SerializeField] private int initialSpawnCount = 10;

    private float timer;
    private List<GameObject> spawnedItems = new List<GameObject>();

    void Start()
    {
        this.ResetSpawner();
    }

    void OnEnable()
    {
        this.ResetSpawner();
    }

    void Update()
    {
        this.spawnedItems.RemoveAll(item => item == null);

        if(this.spawnedItems.Count >= this.maxItems)
        {
            return; 
        }

        this.timer += Time.deltaTime;

        if(this.timer >= this.spawnInterval)
        {
            this.SpawnRandomItem();
            this.timer = 0.0F;
        }
    }

    public void ResetSpawner()
    {
        foreach(GameObject item in this.spawnedItems)
        {
            if(item != null)
            {
                Object.Destroy(item);
            }
        }
        this.spawnedItems.Clear();
        this.timer = 0.0F;

        for(int i = 0; i < this.initialSpawnCount; i++)
        {
            this.SpawnRandomItem();
        }
    }

    private void SpawnRandomItem()
    {
        if(this.itemPrefabs.Length == 0)
        {
            Debug.LogWarning("No item prefabs assigned to the spawner!");
            return;
        }

        int randomIndex = Random.Range(0, this.itemPrefabs.Length);
        GameObject randomPrefab = this.itemPrefabs[randomIndex];

        Vector2 randomPoint = Random.insideUnitCircle * this.spawnRadius;

        Vector3 spawnPosition = new Vector3(
            this.transform.position.x + randomPoint.x, 
            this.spawnHeight, 
            this.transform.position.z + randomPoint.y
        );

        float randomYAngle = Random.Range(0f, 360f);
        Vector3 originalAngles = randomPrefab.transform.eulerAngles;
        Quaternion finalRotation = Quaternion.Euler(originalAngles.x, randomYAngle, originalAngles.z);

        GameObject newItem = Object.Instantiate(randomPrefab, spawnPosition, finalRotation);
        this.spawnedItems.Add(newItem);
    }
}