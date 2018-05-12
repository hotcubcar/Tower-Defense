using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSpawner : MonoBehaviour {

    public GameObject previewTank;
    public float timeBetween;
    public float countdown;
    public Transform spawnPoint;


	// Use this for initialization
	void Start () {
        spawnPoint = GameObject.FindGameObjectWithTag("Start").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (countdown <= 0f)
        {
            Instantiate(previewTank,spawnPoint.position,spawnPoint.rotation);
            countdown = timeBetween;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }
}
