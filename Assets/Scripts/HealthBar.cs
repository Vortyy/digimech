using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image currentHealthbar;
    [SerializeField] GameObject player;
    [SerializeField] GameObject ennemySpawner;
    [SerializeField] GameObject healthBarUI;
    [SerializeField] GameObject sickSoundtrack;
    [SerializeField] GameObject deathMenu;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioSource death;

    public float hitpoint = 100;
    public float maxHitpoint = 100;

    public float damage = 10;

    private void Start()
    {
        UpdateHealthbar();
    }

    private void FixedUpdate()
    {
        if (hitpoint <= 0)
        {
            player.SetActive(false);
            ennemySpawner.SetActive(false);
            healthBarUI.SetActive(false);
            sickSoundtrack.SetActive(false);
            deathMenu.SetActive(true);
            death.PlayOneShot(deathSound);
        }
    }

    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void TakeDamage(float damage)
    {
        hitpoint -= damage;
        UpdateHealthbar();
    }

    public void Heal(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;
        UpdateHealthbar();
    }
}
