using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    //private Transform target;
    //private int wavepointIndex = 0;

    //private Enemy enemy;
    public NavMeshAgent agent;
    public GameObject end;

    // Use this for initialization
    void Start()
    {
        end = GameObject.FindGameObjectWithTag("Finish");
        //enemy = GetComponent<Enemy>();
        //target = Waypoints.points[0];
        agent.SetDestination(end.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance == 0f && !agent.pathPending)
        {
            EndPath();
        }
    }
    //    Vector3 dir = target.position - transform.position;
    //    transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

    //    if (Vector3.Distance(transform.position, target.position) <= 0.5f)
    //    {
    //        GetNextWaypoint();
    //    }

    //    //Vector3 dir = target.position - transform.position;
    //    Quaternion lookRotation = Quaternion.LookRotation(dir);
    //    Vector3 rotation = Quaternion.Lerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * enemy.turnSpeed).eulerAngles;
    //    gameObject.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    //    enemy.speed = enemy.startSpeed;
    //}

    //void GetNextWaypoint()
    //{
    //    if (wavepointIndex >= Waypoints.points.Length - 1)
    //    {

    //        EndPath();
    //        return;
    //    }

    //    wavepointIndex++;
    //    target = Waypoints.points[wavepointIndex];
    //}

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
