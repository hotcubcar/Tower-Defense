using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform enemyPrefab;
    public Transform airplanePrefab;
    public Transform robotPrefab;

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

    }

    // Update is called once per frame
    void Update()
    {

        if (EnemiesAlive > 0)
        {
            return;
        }
        

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveNumberText.text = "Wave: " + waveIndex;
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;
        //if (waveIndex % 10 == 0)
        //{
        //    SpawnRobot();
        //}

        Wave wave = waves[waveIndex];


        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            //SpawnAirplane();
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            //Next Level
            Debug.Log("Level Won!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        //if (waveIndex % 2 == 0)
        //{
        //    SpawnAirplane();
        //}
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

    //void SpawnAirplane()
    //{
    //    Instantiate(airplanePrefab, spawnPoint.position, spawnPoint.rotation);
    //}

    //void SpawnRobot()
    //{
    //    Instantiate(robotPrefab, spawnPoint.position, spawnPoint.rotation);
    //}
}
