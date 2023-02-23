using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{

    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform[] spawnLocation;
    public int spawnIndex;

    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    public GameObject Block;
    public TMP_Text waveCounterText;
    public TMP_Text zombieCounterText;



    public List<GameObject> spawnedEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            //spawn an enemy
            if (enemiesToSpawn.Count > 0)
            {
                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocation[spawnIndex].position, Quaternion.identity); // spawn first enemy in our list
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnedEnemies.Add(enemy);
                spawnTimer = spawnInterval;

                if (spawnIndex + 1 <= spawnLocation.Length - 1)
                {
                    spawnIndex++;
                }
                else
                {
                    spawnIndex = 0;
                }
            }
            //else
            //{
            //    waveTimer = 0; // if no enemies remain, end wave
            //}
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            
        }

        if (spawnedEnemies.Count <= 0)
        {
            waveTimer -= Time.fixedDeltaTime;
        }

        if (waveTimer <= 0 && spawnedEnemies.Count <= 0)
        {
            currWave++;
            GenerateWave();
        }

        if (spawnedEnemies.Count + enemiesToSpawn.Count > 5)
        {
            zombieCounterText.text = "";
        }
        else
        {
            zombieCounterText.text = "Zombies left: " + (spawnedEnemies.Count + enemiesToSpawn.Count);
        }

        waveCounterText.text = ToRoman(currWave);
    }

    public int GetWave()
    {
        return currWave;
    }

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        GenerateEnemies();

        spawnInterval = 5; // gives a fixed time between each enemies
        waveTimer = waveDuration; // wave duration is read only
    }

    public void GenerateEnemies()
    {
        // Create a temporary list of enemies to generate
        // 
        // in a loop grab a random enemy 
        // see if we can afford it
        // if we can, add it to our list, and deduct the cost.

        // repeat... 

        //  -> if we have no points left, leave the loop

        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    void Update()
    {
        if (currWave >= 10)
        {
            Block.SetActive(false);
        }
    }

    public static string ToRoman(int number)
    {
        if (number < 1) return "";
        if (number >= 1000)
        {
            return "M" + ToRoman(number - 1000);
        }
        else if (number >= 900) { return "CM" + ToRoman(number - 900); }
        else if (number >= 500) { return "D" + ToRoman(number - 500); }
        else if (number >= 400) { return "CD" + ToRoman(number - 400); }
        else if (number >= 100) { return "C" + ToRoman(number - 100); }
        else if (number >= 90) {return "XC" + ToRoman(number - 90); }
        else if (number >= 50) {return "L" + ToRoman(number - 50); }
        else if (number >= 40) {return "XL" + ToRoman(number - 40); }
        else if (number >= 10){ return "X" + ToRoman(number - 10); }
        else if (number >= 9){ return "IX" + ToRoman(number - 9); }
        else if (number >= 5){ return "V" + ToRoman(number - 5); }
        else if (number >= 4) {return "IV" + ToRoman(number - 4); }
        else { return "I" + ToRoman(number - 1); }

    }
    
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
