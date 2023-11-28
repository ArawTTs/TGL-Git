using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemInstantiateControl : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public float respawnDelay = 6f; 
    public int maxEnemies = 10;
    public float totalSpawnTime = 12f; 

    private Camera mainCamera;
    private List<GameObject> enemies = new List<GameObject>();
    private float elapsedSpawnTime = 0f;
    private bool spawningEnabled = true;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (spawningEnabled && enemies.Count < maxEnemies && elapsedSpawnTime < totalSpawnTime)
        {
            Vector3 randomPosition = GetRandomOffscreenPosition();
            GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enemies.Add(newEnemy);
            elapsedSpawnTime += spawnInterval;
        }
        else
        {
            spawningEnabled = false; 
        }
    }

    void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                StartCoroutine(RespawnDelayCoroutine()); 
                enemies.RemoveAt(i);
                break;
            }
        }

        if (enemies.Count == 0 && !spawningEnabled)
        {
            Debug.Log("No enemies remaining.");
            SceneManager.LoadScene("Combat");
        }
    }

    IEnumerator RespawnDelayCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        spawningEnabled = true; // Re-enable spawning after delay
    }
    Vector3 GetRandomOffscreenPosition()
    {
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float randomX = Random.Range(cameraWidth * 1.5f, cameraWidth * 2.5f);
        float randomY = Random.Range(cameraHeight * 1.5f, cameraHeight * 2.5f);

        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0: return new Vector3(Random.Range(-randomX, randomX), randomY, 0f); // Top 
            case 1: return new Vector3(Random.Range(-randomX, randomX), -randomY, 0f); // Bottom 
            case 2: return new Vector3(-randomX, Random.Range(-randomY, randomY), 0f); // Left 
            case 3: return new Vector3(randomX, Random.Range(-randomY, randomY), 0f); // Right 
            default: return Vector3.zero;
        }
    }


}
