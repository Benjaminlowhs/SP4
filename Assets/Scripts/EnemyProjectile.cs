using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Player player;
    public GameObject puke;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.TakeDamage(20);
            Destroy(puke);
        }
    }
}
