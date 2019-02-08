using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSpawner : MonoBehaviour
{
    //general
    [SerializeField]
    private Transform scenario;
    private int length;
    [SerializeField]
    private float padding; //Space between rocks;

    //rocks
    private int [] predefinedRockSizes = new int[3] {4,6,8};
    private int[] heights;
    [SerializeField]
    private GameObject rockPrefab;
    private GameObject[] rocks;

    //castles
    private GameObject castlePrefab;
    private GameObject[] castles;

    
    private void Start()
    {
        InitializeHeights();
        SpawnScenario();
    }

    private void SpawnScenario()
    {
        SpawnRocks();
        SpawnCastles();
    }

    private void SpawnRocks()
    {
        rocks = new GameObject[length];
        Vector3 pos = Vector3.zero;
        Quaternion rot = rockPrefab.transform.rotation;

        for (int i = 0; i < length; i++)
        {
            pos += Vector3.right * heights[i] * 5;
            rocks[i] = Instantiate(rockPrefab, pos, rot, scenario);
            Vector3 scale = Vector3.one * heights[i];
            rocks[i].transform.localScale = scale;
        }
    }

    private void SpawnCastles()
    {

    }

    private void InitializeHeights()
    {
        length = Random.Range(3,8);
        heights = new int[length];
        for (int i = 0; i < length; i++)
        {
            heights[i] = predefinedRockSizes[Random.Range(0, 3)];
        }
    }


}
