﻿using System.Collections;
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
    public GameObject missileTurret;

    void Start()
    {
        //turretToBuild = standardTurretPrefab;
        //turretToBuild = turret2;
    }

    public bool CanBuild { get { return turretToBuild != null; } }

    private TurretBlueprint turretToBuild;

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Money Left " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
