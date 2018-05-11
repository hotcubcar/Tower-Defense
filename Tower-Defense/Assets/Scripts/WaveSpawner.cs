using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform tankPrefab;
    public Transform airplanePrefab;
    public Transform robotPrefab;

    public GameObject[] spawnPoints;
    public int currentSpawnPoint = 0;
    public Transform spawnPoint;

    public float timeBetweenWaves = 2f;
    private float countdown = 2f;
    public int maxWaveCount = 10;

    public Text waveCountdownText;
    public Text waveNumberText;

    private int waveIndex = 0;

    // Use this for initialization
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Start");
        spawnPoint = spawnPoints[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        waveNumberText.text = "Enemies: " + EnemiesAlive;
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            //Next Level
            Debug.Log("Level Won!");
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //waveNumberText.text = "Wave: " + waveIndex;
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;
        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            //SpawnAirplane();
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        NextSpawnPoint();
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

    void NextSpawnPoint()
    {
        if (spawnPoints.Length > 1)
        {
            spawnPoint = spawnPoints[currentSpawnPoint].transform;
            currentSpawnPoint++;
            if (currentSpawnPoint >= spawnPoints.Length)
            {
                currentSpawnPoint = 0;
            }
        }
    }
}
