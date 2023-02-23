using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public ParticleSystem explosionParticle;

    float timer = 0f;
    float timeToExplode = 2f;
    float range = 5f;

    void Explode()
    {
        Instantiate(explosionParticle, gameObject.transform.position, gameObject.transform.rotation);

        Collider[] targetsHit = Physics.OverlapSphere(gameObject.transform.position, range);
        Damage(targetsHit);

        Destroy(gameObject);
    }

    void Damage(Collider[] targetsHit)
    {
        foreach(Collider target in targetsHit)
        {
            EnemyController enemy = target.GetComponent<EnemyController>();
            if (enemy == null)
                continue;

            enemy.TakeDamage(500);
        }
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer > timeToExplode)
            Explode();
    }
}
