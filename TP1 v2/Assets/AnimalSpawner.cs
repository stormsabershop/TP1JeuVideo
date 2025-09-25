using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;  // Assign in inspector
    public float spawnInterval = 3f;    // Base time between spawns
    private float timer;


    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        timer = spawnInterval;
    }

    void Update()
    {
        if (playerController.gameOver) return;
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnAnimal();
            // variations du temps entre les apparitions
            timer = spawnInterval + Random.Range(-spawnInterval * 0.5f, spawnInterval * 0.5f);
        }
    }

    void SpawnAnimal()
    {
        // Pick random prefab
        int index = Random.Range(0, animalPrefabs.Length);

        // Pick random X position (adjust values to your scene)
        float randomX = Random.Range(-9f, 9f);

        // Spawn above camera view
        Vector3 spawnPos = new Vector3(randomX, 0f, 25f);

        Instantiate(animalPrefabs[index], spawnPos, Quaternion.identity);
    }
}
