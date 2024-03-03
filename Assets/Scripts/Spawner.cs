using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

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
    public AudioSystem audioSystem;
    public AudioClip startWaveSound;
    public TMP_Text waveStartText;
    int waveCount;


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
            audioSystem.Play(startWaveSound);
            waveCount++;
            waveStartText.text = "Wave " + waveCount;
            await new WaitForSeconds(2f);
            waveStartText.text = "";
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
