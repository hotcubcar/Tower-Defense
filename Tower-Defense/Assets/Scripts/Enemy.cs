using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float turnSpeed = 10f;
    public float health = 100;

    public int value = 50;

    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
    }
	
    public void TakeDamage(float amount)
    {
        health -= amount;
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
