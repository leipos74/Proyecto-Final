using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawnner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
    public TextMeshProUGUI waveName;
    public TextMeshProUGUI waveCounter;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;
    private bool waveInProgress = false;


    private void Start()
    {
        currentWaveNumber = 0;
        UpdateUI();
    }

    void Update()
    {
        if (!waveInProgress)
        {
            if (currentWaveNumber == waves.Length)
            {
                Debug.Log("GameFinish");
                return;
            }

            currentWave = waves[currentWaveNumber];
            waveInProgress = true;
            UpdateUI();
        }

        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && currentWaveNumber == 1)
        {
            waveInProgress = false;
            canSpawn = true;
            UpdateUI();
            currentWaveNumber++;
        }
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if (currentWave.noOfEnemies == 0)
            {
                canSpawn = false;
            }
        }

    }

    void UpdateUI()
    {
        if (currentWaveNumber == waves.Length)
        {
            waveName.text = "Game Finish";
        }
        else if (waveInProgress)
        {
            waveName.text = currentWave.waveName;
        }
        else
        {
            waveName.text = "";
        }

        waveCounter.text = "Wave " + (currentWaveNumber + 1) + " of " + waves.Length;
    }
}