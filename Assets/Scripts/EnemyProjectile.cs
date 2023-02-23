using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Player player;
    public GameObject puke;
    private float pukeTimer;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
        pukeTimer = 5;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.TakeDamage(20);
            Destroy(puke);
        }
    }

    private void Update()
    {
        Destroy(puke, pukeTimer);
    }
}
