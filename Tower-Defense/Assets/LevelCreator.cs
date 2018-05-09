using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelCreator : MonoBehaviour {

    [HideInInspector]
    public Texture2D map;
    public NavMeshSurface surface;
    public Texture2D[] maps;
    //public int width = 10;
    //public int height = 10;
    //public int offset = 0;
    public GameObject player;
    public ColorToPrefab[] colorMappings;
    private GameObject start;
    private GameObject end;


    // Use this for initialization
    void Start () {
        //GameObject start = GameObject.FindGameObjectWithTag("Start");
        //end = GameObject.FindGameObjectWithTag("Finish");
        PickMap();
        CreateLevel();
        surface.BuildNavMesh();
        Instantiate(player, GameObject.FindGameObjectWithTag("Start").transform.position,Quaternion.identity);
	}

    void PickMap()
    {
        //int mapNum = Random.Range(0, maps.Length);
        map = maps[Random.Range(0, maps.Length)];
        //Debug.Log(map.name);
    }

    void CreateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
    }

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        if (pixelColor == Color.white)
        {
            //white pixel
            return;
        }
        //Debug.Log(pixelColor);

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color == pixelColor)
            {
                Vector3 position = new Vector3(x * 2, 2, z * 2);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }

    }
	
}
