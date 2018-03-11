using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    BuildManager buildManager;

    public Color hoverColor;
    private Color startColor;
    public Vector3 turretOffset;
    private Renderer rend;

    private GameObject turret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.getTurretToBuild() == null)
        {
            return;
        }
        
        if (turret != null)
        {
            Debug.Log("Already Built");
            return;
        }

        GameObject turretToBuild = buildManager.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + turretOffset, transform.rotation);

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.getTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
	
}
