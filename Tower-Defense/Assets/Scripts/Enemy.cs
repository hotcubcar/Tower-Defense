using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    private float health = 100;
    public float startHealth;

    public int value = 50;

    [Header("Unity Stuff")]
    public Canvas EnemyDisplay;
    public Image healthbar;
    public GameObject mainCamera;
    public NavMeshAgent agent;
    public GameObject end;

    public GameObject deathEffect;

    void Start()
    {
        agent.speed = startSpeed;
        health = startHealth;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        end = GameObject.FindGameObjectWithTag("Finish");
        agent.SetDestination(end.transform.position);
    }

    void Update()
    {
        EnemyDisplay.transform.LookAt(mainCamera.transform);
        if (agent.remainingDistance == 0f && !agent.pathPending)
        {
            EndPath();
        }
        agent.speed = startSpeed;
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
        agent.speed = startSpeed * (1f - amount);
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }


    void Die()
    {
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }



}
