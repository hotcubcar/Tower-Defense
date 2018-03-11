using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Build Manager!");
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject turret2;

    void Start()
    {
        //turretToBuild = standardTurretPrefab;
        turretToBuild = turret2;
    }

    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
