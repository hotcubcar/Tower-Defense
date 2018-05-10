using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{

    public NavMeshSurface surface;

    //public int width = 10;
    //public int height = 10;
    //public int offset = 0;
    public GameObject wall;
    //public float wallSize = 2f;
    public GameObject player;
    public GameObject start;
    public GameObject end;
    public Vector3 startpos;
    public Vector3 currentPos;
    public int pathLength;
    public List<Vector3> pathHistory;
    public bool badpath = false;
    public int badPathCount = 0;

    //private bool playerSpawned = false;

    // Use this for initialization
    void Start()
    {
        //GenerateLevel();
        GeneratePath();
        surface.BuildNavMesh();
        //GameObject testAI = 
        Instantiate(player, startpos, Quaternion.identity);
        //NavMeshAgent agent = testAI.GetComponent<NavMeshAgent>();
        //agent.SetDestination(pathHistory[pathHistory.Count  - 1]);
        //while (agent.pathPending)
        //{
                //Need to move this to first run of Update or something
        //}
        //Debug.Log(agent.remainingDistance);
    }

    void GeneratePath()
    {
        //Debug.Log("Generating Path");
        //spawn start
        Instantiate(start, startpos + Vector3.up, Quaternion.identity, transform);
        //Instantiate(wall, startpos, Quaternion.identity, transform);
        do
        {
            //for loop,  length of path
            currentPos = startpos;
            for (int i = 0; i < pathLength; i++)
            {
                //put path pos in pathhistory
                pathHistory.Add(currentPos);
                //pick direction without path
                //Debug.Log("finding path #" + i);
                currentPos = NextPath(currentPos, pathHistory);
                if (badpath)
                {
                    //Debug.Log("bad path");
                    badPathCount++;
                    pathHistory.Clear();
                    break;
                }
            }//end for loop
        } while (badpath); // if path bad

        //Debug.Log("Spawning Path");
        //spawn path
        foreach (Vector3 pos in pathHistory)
        {
            Instantiate(wall, pos, Quaternion.identity, transform);
        }

        //spawn end
        Instantiate(end, pathHistory[pathHistory.Count - 1] + Vector3.up, Quaternion.identity, transform);
        Debug.Log(badPathCount + " Bad Paths");
    }

    Vector3 NextPath(Vector3 pos, List<Vector3> history)
    {
        Vector3 dir;
        int badPathCount = 0;
        badpath = false;
        //TODO Check if direction is available
        do
        {
            float val = Random.value;
            //Debug.Log(val);
            if (val > 0.75)
            {
                dir = Vector3.forward;
            }
            else if (val > 0.50)
            {
                dir = Vector3.left;
            }
            else if (val > 0.25)
            {
                dir = Vector3.back;
            }
            else
            {
                dir = Vector3.right;
            }
            //TODO Build it bad path detection
            badPathCount++;
            if (badPathCount > 5)
            {
                badpath = true;
                break;
            }
        } while (history.Contains(pos + dir * 2));

        return pos += dir * 2;
    }
}
