using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSpawner : MonoBehaviour
{
    //general
    [SerializeField]
    private Transform scenario;
    private int length;

    //rocks
    private int [] predefinedRockSizes = new int[3] {4,6,8};
    private int[] heights;
    [SerializeField]
    private GameObject rockPrefab;
    private GameObject[] rocks;

    //towers
    private GameObject towerPrefab;
    private GameObject[] towers;

    
    private void Start()
    {
        InitializeHeights();
        SpawnScenario();
    }

    private void SpawnScenario()
    {
        rocks = new GameObject[length];
        
        for(int i=0;i<length;i++)
        {
            rocks[i] = Instantiate(rockPrefab, transform.position, rockPrefab.transform.rotation ,scenario);
            Vector3 scale = Vector3.one * heights[i];
            rocks[i].transform.localScale = scale;
        }
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
