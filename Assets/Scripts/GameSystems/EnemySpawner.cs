using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public int enemiesPerWave = 3;
    public int maxWaves;

    private List<GameObject> lastWaveEnemies = new List<GameObject>();
    private int waveCounter = 0;

    void Start()
    {
        StartCoroutine(WaveLoop());
    }

    IEnumerator WaveLoop()
    {
        while (true)
        {
            if (waveCounter >= maxWaves)
            {
                Debug.Log("Max waves reached.");
                yield break;
            }

            // 1. Maak X vijanden klaar (maar nog niet actief)
            PrepareEnemies();

            // 2. Wacht Y seconden (bijv. 5 seconden)
            yield return new WaitForSeconds(timeBetweenWaves);

            // 3. (Gaat nu terug naar begin en maakt nieuwe klaar terwijl deze aanvallen)
        }
    }

    void PrepareEnemies()
    {
        waveCounter++;
        List<GameObject> newWave = new List<GameObject>();

        for (int i = 0; i < enemiesPerWave; i++)
        {
            GameObject source = (lastWaveEnemies.Count > i) ? lastWaveEnemies[i] : enemyPrefab;
            Vector3 spawnPosition = spawnPoint.position + new Vector3(i * 2f, 0, 0);
            GameObject enemy = Instantiate(source, spawnPosition, Quaternion.identity);
            enemy.name = "Enemy Wave " + waveCounter + " - " + ((i % enemiesPerWave) + 1);
            enemy.SetActive(false);
            StartCoroutine(ActivateEnemyAfterDelay(enemy));
            newWave.Add(enemy);
        }

        lastWaveEnemies = newWave;
    }

    IEnumerator ActivateEnemyAfterDelay(GameObject enemy)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        if (enemy != null)
            enemy.SetActive(true);
    }
}