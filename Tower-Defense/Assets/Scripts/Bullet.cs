using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public int damage = 50;
    public float speed = 70;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public string enemyTag = "Enemy";
    public int range = 0;
    private bool isGuided = false;
    public bool isRocket()
    {
        if (range != 0)
        {
            return true;
        }
        return false;
    }
    public int rocketArc = 0;

    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Use this for initialization
	void Start () {
            isGuided = isRocket();        
	}
	
	// Update is called once per frame
	void Update () {

        if (isGuided)
        {
            transform.rotation = Quaternion.Euler(Vector3.right * -90); //Look Up
            if (transform.position.y < rocketArc) //Not High Enough?
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World); //Move Up
                return;
            }
            isGuided = false; //High Enough, No More Up
        }
        else
        {

            if (target == null)
            {
                if (!isRocket())
                {
                    Destroy(gameObject);
                    return;
                }
                GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
                float shortestDistance = Mathf.Infinity;
                GameObject nearestEnemy = null;
                foreach (GameObject enemy in enemies)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
                }

                if (nearestEnemy != null && shortestDistance <= range)
                {
                    target = nearestEnemy.transform;
                }
                else
                {
                    Destroy(gameObject);
                    return;
                }
            }

            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);

            if (isRocket())
            {
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * 5).eulerAngles;
                gameObject.transform.rotation = Quaternion.Euler(rotation);
            }
            else
            {
                transform.LookAt(target);
            }
        }
	}

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            //Debug.Log("Explode check on "  + collider.tag);
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        //Debug.Log("Destroy check on " + enemy.name);
        //enemy = enemy.parent.parent;

        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
        //Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
