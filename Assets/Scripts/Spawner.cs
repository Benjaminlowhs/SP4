using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int counter;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnEnemy()
    {
        if (--counter == 0) CancelInvoke("spawnEnemy");
        Instantiate(enemies[0], new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5)), Quaternion.identity);
    }
}
