using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<Transform> spawnPoints;
    [Header("Settings")]
    [Range(0.1f, 10f)]public float spawnInterval = 1f;
    public int enemiesToSpawn;
    public List<int> enemiesPerWave;
    [Range(0.1f, 10f)] public float timeBetweenWaves;
    public UnityEvent onWaveStart;
    public UnityEvent onWaveEnd;
    public UnityEvent onWavesCleared;


    void Spawn()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(prefab, point.position, transform.rotation);
    }
    async void Start()
    {
        foreach (var num in enemiesPerWave) //waves
        {
            enemiesToSpawn = num;
            onWaveStart.Invoke();
            while(enemiesToSpawn > 0)
            {
                await new WaitForSeconds(spawnInterval);
                Spawn();
                enemiesToSpawn--;
            }
            onWaveEnd.Invoke();
            await new WaitForSeconds(timeBetweenWaves);
        }
        onWavesCleared.Invoke();

    }
}
