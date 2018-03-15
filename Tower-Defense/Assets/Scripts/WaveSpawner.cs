using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform airplanePrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
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
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveNumberText.text = "Wave: " + waveIndex;
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        if (waveIndex < maxWaveCount)
        {
            waveIndex++;
        }
        //waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            SpawnAirplane();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnAirplane()
    {
        Instantiate(airplanePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
