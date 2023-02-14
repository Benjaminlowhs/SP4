using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public Camera fpsCamera;
    // public ParticleSystem muzzleFlash;
    // public GameObject impactEffect;

    public float damage = 10f;
    public float range = 100f;

    void Shoot()
    {
        // muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyController enemy = hit.transform.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
