using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour {

    public NavMeshSurface surface;

    public int width = 10;
    public int height = 10;
    public int offset = 0;
    public GameObject wall;
    public float wallSize = 2f;
    public GameObject player;

    private bool playerSpawned = false;

	// Use this for initialization
	void Start () {
        GenerateLevel();
        surface.BuildNavMesh();
	}

    void GenerateLevel()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (Random.value > 0.7f)
                {
                    //spawn obstacle
                    Vector3 pos = new Vector3((x * wallSize)+ offset, 1f, (y * wallSize) + offset);
                    Instantiate(wall, pos, Quaternion.identity, transform);
                }
                else if (!playerSpawned)
                {
                    Vector3 pos = new Vector3((x * wallSize) + offset, 1.25f, (y * wallSize) + offset);
                    Instantiate(player, pos, Quaternion.identity);
                    playerSpawned = true;
                }




            }
        }
    }
}
