using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public List<GameObject> diffEnemies = new List<GameObject>();//Ennemis différents
    public List<GameObject> enemiesToSpawn = new List<GameObject>(); //Ennemis qui spawnent pendant la wave actuelle

    [Header("Wave Editor")]
    public int numberSpawnsFirstWave;
    public int maxSpawnsByWave;
    public int addedEachWave = 3;
    public int waveNumber = 1;
    public int timerWave = 10;

    [Header("Enemy Spawns Area")]
    public float xMinMap;
    public float xMaxMap;
    public float yMinMap;
    public float yMaxMap;

    bool canSpawn;

    PlayerController player;
    void Start()
    {
        canSpawn = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        
        if (canSpawn)
        {
            
            for (int i = 0; i < diffEnemies.Count; i++)
            {
                if (diffEnemies[i].GetComponent<EnemyMovements>().enemyStartSpawningWave == waveNumber)
                {
                    enemiesToSpawn.Add(diffEnemies[i]);
                }
            }
            for(int i = 0; i < numberSpawnsFirstWave; i ++)
            {

               GameObject spawningEnemy = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];

               Instantiate(spawningEnemy, new Vector2(Random.Range(xMinMap, xMaxMap), Random.Range(yMinMap, yMaxMap)), spawningEnemy.transform.rotation);
            }
            canSpawn = false;
            StartCoroutine(Wave());
        }
        
    }

    IEnumerator Wave()
    {
        waveNumber += 1;
        if(numberSpawnsFirstWave < maxSpawnsByWave)
        {
            numberSpawnsFirstWave += addedEachWave;
            addedEachWave++;
        }
        else
        {
            numberSpawnsFirstWave += maxSpawnsByWave;
        }
        StartTimerWave();
        yield return new WaitForSeconds(10f);
        canSpawn = true;
    }

    IEnumerator TimerWave()
    {
        timerWave += 10;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            timerWave -= 1;
        }
        
    }

    void StartTimerWave()
    {
        StartCoroutine(TimerWave());
    }
}
