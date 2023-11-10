using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab ;
    public GameObject[] powerupPrefabs;
    private float spawnRange = 9f;
    public int numberOfEnemies;
    public int waveNumber = 1;
    


    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(waveNumber);
        CreatePowerup();
    }

    // Update is called once per frame
    void Update()
    {
        numberOfEnemies = FindObjectsOfType<Enemy>().Length;
        if (numberOfEnemies == 0){
            waveNumber++;
            SpawnWave(waveNumber);
            CreatePowerup();
        }

        
    }

    private void SpawnWave(int enemiesToSpawn){
        for (int i  = 0; i < enemiesToSpawn ; i++){
            CreateEnemy();
            
        }
    }

    private void CreatePowerup(){
        //Instantiate(powerupPrefabs[0], GenerateRandomPosition(), powerupPrefabs[0].transform.rotation);
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerup], GenerateRandomPosition(), powerupPrefabs[randomPowerup].transform.rotation);
    }
    private void CreateEnemy(){
        int index = Random.Range(0,2);
        
        Instantiate(enemyPrefab[index], GenerateRandomPosition(), enemyPrefab[index].transform.rotation);
    }

    private Vector3 GenerateRandomPosition(){
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xPos , 0 , zPos);
        return spawnPos;
    }
}
