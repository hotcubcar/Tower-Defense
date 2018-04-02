using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float turnSpeed = 10f;
    private float health = 100;
    public float startHealth;

    public int value = 50;

    [Header("Unity Stuff")]
    public Image healthbar;

    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
	
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthbar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }


    void Die()
    {
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
        Destroy(gameObject);
    }



}
