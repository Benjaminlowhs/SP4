using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform target;

    Animator animator;

    public float health = 100f;
    public float speed = 1.0f;
    private bool isMobilized;
    private Player player;
    float damageTick = 2f;
    float currentTime = 0f;
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
        currentTime += 2f * Time.deltaTime;
        enemy.SetDestination(target.position);
        GetComponent<Animator>().ResetTrigger("Attack");
        //enemy.transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position);
        //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.position, speed * Time.deltaTime);

        RaycastHit hit;
        var rayDirection = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, 10f))
        {
            Debug.Log("Hit");
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if (Vector3.Distance(enemy.transform.position, target.position) < 3f)
                {
                    GetComponent<Animator>().SetTrigger("Attack");

                    isMobilized = false;


                } 
                if (currentTime >= damageTick)
                {

                     CheckForPlayer();
                     currentTime = 0f;
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
            player.TakeDamage(20);
        Debug.Log("Attackingg");
    }

    void CheckForPlayer()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, 6f);
        foreach (Collider c in collider)
        {
            if (c.GetComponent<Player>())
            {
                c.GetComponent<Player>().TakeDamage(2);
            }
        }
    }
}
