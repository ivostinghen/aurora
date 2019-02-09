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
    private int [] predefinedRockSizes = new int[4] {3,6,9,12};
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
            heights[i] = predefinedRockSizes[Random.Range(0, 4)];
        }
    }

    private float CalculateBoundDist(Collider col1, Collider col2)
    {
        Vector3 closestSurfacePoint1 = col1.ClosestPointOnBounds(col2.transform.position);
        Vector3 closestSurfacePoint2 = col2.ClosestPointOnBounds(col1.transform.position);
        Vector3 dif = (closestSurfacePoint2-closestSurfacePoint1);
        return dif.x;
    }

    private void SpawnRocks()
    {
        rocks = new GameObject[rocksAmount];
        Vector3 pos = Vector3.zero;
        Quaternion rot = rockPrefab.transform.rotation;
        Vector3 margin = Vector3.zero;
        for (int i = 0; i < rocksAmount; i++)
        {
            rocks[i] = Instantiate(rockPrefab, pos, rot, scenario);
            Vector3 scale = Vector3.one * heights[i];
            rocks[i].transform.localScale = scale;
            if(i!=0)
            {
                Collider col1, col2;
                col1 = rocks[i-1].GetComponent<Collider>();
                col2 = rocks[i].GetComponent<Collider>();
                float d = 0;
                while (d < 30)
                {
                    d = CalculateBoundDist(col1,col2);
                    rocks[i].transform.position += Vector3.right;
                }
            }
            
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

    public void ActivateScenario()
    {
        foreach (GameObject castle in castles)
        {
            castle.SetActive(true);
        }
        foreach (GameObject rock in rocks)
        {
            rock.SetActive(true);
        }
    }

    private void SpawnScenario()
    {
        SpawnRocks();
        SpawnCastles();
        ActivateScenario();
    }

    private void Start()
    {
        InitializeHeights();
        SpawnScenario();
        Controller.instance.SetPowerAmount(castlesAmount);

    }








}
