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
    void Update()
    {
        enemy.SetDestination(target.position);

        if (Vector3.Distance(enemy.transform.position, target.position) < 3f)
        {
            GetComponent<Animator>().SetTrigger("Attack");
            Debug.Log("Attack");
        }

    }
}
