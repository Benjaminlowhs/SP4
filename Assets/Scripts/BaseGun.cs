using UnityEngine;
using TMPro;

public class BaseGun : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public GameObject bloodSpray;
    public AudioSource bangSound;
    public AudioSource reloadingSound;
    public GameObject crosshair;
    public TMP_Text currentLoad;
    public TMP_Text totalLoad;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    public int magSize = 5;
    public float reloadTime = 5f;
    public float rotateSpeed = 6f;


    Camera fpsCamera;
    float nextTimeToFire = 0f;
    float currentMagSize = 5;
    float nextTimeReloadFinish = 0f;
    bool isReloading = false;

    void Shoot()
    {
        muzzleFlash.Play();

        bangSound.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            EnemyController enemy = hit.transform.GetComponent<EnemyController>();
            if (enemy != null)
            {
                Instantiate(bloodSpray, hit.point, Quaternion.LookRotation(hit.normal));
                enemy.TakeDamage(damage);
            }
            RangedEnemyController rangedEnemy = hit.transform.GetComponent<RangedEnemyController>();
            if (rangedEnemy != null)
            {
                Instantiate(bloodSpray, hit.point, Quaternion.LookRotation(hit.normal));
                rangedEnemy.TakeDamage(damage);
            }
            BossController bossEnemy = hit.transform.GetComponent<BossController>();
            if (bossEnemy != null)
            {
                Instantiate(bloodSpray, hit.point, Quaternion.LookRotation(hit.normal));
                bossEnemy.TakeDamage(damage);
            }
        }

    }

    void Reload()
    {
        reloadingSound.Play();

        isReloading = true;
        currentMagSize = magSize;
    }

    void Start()
    {
        if (fpsCamera == null)
            fpsCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        currentMagSize = magSize;
    }

    void Update()
    {
        currentLoad.text = currentMagSize.ToString();
        totalLoad.text = magSize.ToString();

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentMagSize > 0 && !isReloading)
        {
            Shoot();
            nextTimeToFire = Time.time + 1f/fireRate;
            currentMagSize -= 1;
        }

        if (Time.time >= nextTimeReloadFinish)
        {
            isReloading = false;
            crosshair.transform.rotation = Quaternion.identity;
        }

        if (Input.GetKeyDown(KeyCode.R) && Time.time >= nextTimeReloadFinish)
        {
            if (isReloading)
                return;

            if (currentMagSize >= magSize)
                return;

            Reload();
            nextTimeReloadFinish = Time.time + reloadTime;
        }

        if (isReloading && Time.time <= nextTimeReloadFinish)
        {
            crosshair.transform.Rotate(0,0,rotateSpeed);
        }
    }
}
