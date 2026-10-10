using UnityEngine;

public class ConsumableSpawner : MonoBehaviour
{
    [Header("Item Prefabs")]
    [SerializeField] private GameObject[] itemPrefabs;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 3.0F;
    [SerializeField] private float spawnRadius = 20.0F; 
    [SerializeField] private float spawnHeight = 0.0F;

    private float timer;

    void Update()
    {
        this.timer += Time.deltaTime;

        if(this.timer >= this.spawnInterval)
        {
            this.SpawnRandomItem();
            this.timer = 0.0F;
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

        Object.Instantiate(randomPrefab, spawnPosition, finalRotation);
    }
}