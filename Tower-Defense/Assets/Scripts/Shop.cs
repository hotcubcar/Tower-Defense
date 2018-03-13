using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint turret2;
    public TurretBlueprint nukeLauncher;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

	public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectTurret2()
    {
        buildManager.SelectTurretToBuild(turret2);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectNukeLauncher()
    {
        buildManager.SelectTurretToBuild(nukeLauncher);
    }

}
