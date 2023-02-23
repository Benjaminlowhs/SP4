using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyController : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform target;
    public GameObject projectile;
    public Transform spawnPoint;

    Animator animator;

    public float health = 25f;
    public float speed = 1.5f;
    public float bulletSpeed = 10f;
    private bool isMobilized;
    private Player player;
    private float range = 100f;
    
    //private bool isChasing = true;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(enemy);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = FindObjectOfType<Player>();
        enemy.SetDestination(target.position);


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        enemy.SetDestination(target.position);
        GetComponent<Animator>().ResetTrigger("Attack");
        //enemy.transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position);
        //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.position, speed * Time.deltaTime);

        RaycastHit hit;
        var rayDirection = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, range))
        {
            Debug.Log("Hit");
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if (Vector3.Distance(enemy.transform.position, target.position) < 10f)
                {
                    GetComponent<Animator>().SetTrigger("Attack");

                    isMobilized = false;


                }
            }
        }

    }

    void ResetMobility()
    {
        isMobilized = true;
    }

    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("Spawner") != null)
        {
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().spawnedEnemies.Remove(gameObject);
        }

    }

    void Attack()
    {
        if (Vector3.Distance(enemy.transform.position, target.position) < 3f)
            player.TakeDamage(10);
        GameObject spitObj = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        spitObj.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
        Debug.Log("Attackingg");
    }
}
