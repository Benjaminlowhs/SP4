using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform target;

    Animator animator;

    public float health = 50f;
    public float speed = 1.5f;
    private bool isMobilized = true;
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
        enemy.SetDestination(target.position);
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Animator>().ResetTrigger("Attack");
        enemy.SetDestination(target.position);
        //enemy.transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position);
        //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(enemy.transform.position, target.position) < 3f)
        {
            Debug.Log(enemy.transform.position + ":" + target.position);
            GetComponent<Animator>().SetTrigger("Attack");
            
            isMobilized = false;
           
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
        Debug.Log("Attack");
    }
}
