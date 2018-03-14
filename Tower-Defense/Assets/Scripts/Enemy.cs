using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public float turnSpeed = 10f;
    public int health = 100;

    public int value = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavepointIndex = 0;

	// Use this for initialization
	void Start () {
        target = Waypoints.points[0];
	}
	
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }

        //Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);


    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {

            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

}
