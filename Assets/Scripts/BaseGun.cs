using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public ParticleSystem muzzleFlash;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    public int magSize = 5;
    public float reloadTime = 5f;

    Camera fpsCamera;
    float nextTimeToFire = 0f;
    float currentMagSize = 5;
    float nextTimeReloadFinish = 0f;
    bool isReloading = false;

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyController enemy = hit.transform.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

        }

    }

    void Reload()
    {
        isReloading = true;
        currentMagSize = magSize;
    }

    void Start()
    {
        if (fpsCamera == null)
            fpsCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentMagSize > 0)
        {
            if (isReloading)
                return;

            Shoot();
            nextTimeToFire = Time.time + 1f/fireRate;
            currentMagSize -= 1;
        }

        if (Time.time >= nextTimeReloadFinish)
            isReloading = false;

        if (Input.GetKeyDown(KeyCode.R) && Time.time >= nextTimeReloadFinish)
        {
            Reload();
            nextTimeReloadFinish = Time.time + reloadTime;
        }
        
        Debug.Log(currentMagSize);
    }
}
