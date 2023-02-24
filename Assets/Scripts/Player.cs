using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Light flashLight;

    public float bloodScreenCounter;
    public GameObject bloodScreen;


    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLight.enabled = !flashLight.enabled;
        }

        if (bloodScreenCounter > 0)
        {
            bloodScreenCounter -= Time.fixedDeltaTime;
            bloodScreen.SetActive(true);
        }
        else
        {
            bloodScreen.SetActive(false);
        }
        Death();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("KOBe");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        bloodScreenCounter = 5;
    }

    public void Heal(int healValue)
    {
        Debug.Log("Heal");
        currentHealth += healValue;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    private void Death()
    {
        if(currentHealth<=0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Lose");
        }
    }
}
