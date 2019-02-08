using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSpawner : MonoBehaviour
{
    //general
    [SerializeField]
    private Transform scenario;
    private int rocksAmount;
    [SerializeField]
    private float padding; //Space between rocks;

    //rocks
    private int [] predefinedRockSizes = new int[3] {4,6,8};
    private int[] heights;
    [SerializeField]
    private GameObject rockPrefab;
    private GameObject[] rocks;

    //castles
    [SerializeField]
    private GameObject castlePrefab;
    private GameObject[] castles;
    private List<int> castlePositions;
    private int castlesAmount;

    private void InitializeHeights()
    {
        rocksAmount = Random.Range(3, 8);
        heights = new int[rocksAmount];
        for (int i = 0; i < rocksAmount; i++)
        {
            heights[i] = predefinedRockSizes[Random.Range(0, 3)];
        }
    }



    private void SpawnRocks()
    {
        rocks = new GameObject[rocksAmount];
        Vector3 pos = Vector3.zero;
        Quaternion rot = rockPrefab.transform.rotation;
        for (int i = 0; i < rocksAmount; i++)
        {
            pos += Vector3.right * heights[i] * 5;
            rocks[i] = Instantiate(rockPrefab, pos, rot, scenario);
            Vector3 scale = Vector3.one * heights[i];
            rocks[i].transform.localScale = scale;
        }
    }

    private void GetCastles()
    {
        CalculateCastles calculateCastles = new CalculateCastles();
        castlesAmount = calculateCastles.solution(heights);
        castlePositions = calculateCastles.GetCastlePositions();
    }

    private void SpawnCastles()
    {
        GetCastles();
        castles = new GameObject[castlesAmount];
        Quaternion rot = castlePrefab.transform.rotation;
        for (int i = 0; i < castlesAmount; i++)
        {
            Transform r = rocks[castlePositions[i]].transform;
            Vector3 pos = r.position;
            pos.y += r.localScale.y * 5.2F;//("altura da rocha")
            castles[i] = Instantiate(castlePrefab, pos, rot, scenario);
            castles[i].transform.parent = r;
        }
    }

    private void SpawnScenario()
    {
        SpawnRocks();
        SpawnCastles();
    }

    private void Start()
    {
        InitializeHeights();
        SpawnScenario();
        Controller.instance.SetPowerAmount(castlesAmount);

    }








}
