using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BesierCurve : MonoBehaviour
{
    [SerializeField]
    private float besierHeight = 5;
    private float besierTime;
    private bool isRunning;
    private Vector3 A, B, C;
    [SerializeField]
    private float forwardDistance;
    [SerializeField]
    private float speed;

    private Vector3 CalculateBesier(float t)
    {
        besierTime += Time.deltaTime * speed / 100;
        Vector3 besierPos = (A - (2 * t * A) + (t * t * A)) + ((2 * t * B) - (2 * t * t * B)) + (t * t * C);
        return besierPos;
    }

    public void RunBesier()
    {
        Vector3 besierStartPoint = this.transform.position;
        A = besierStartPoint;
        C = besierStartPoint + Camera.main.transform.forward * forwardDistance;
        B = (A + C) / 2;
        B.y += besierHeight;
        isRunning = true;
    }

    public void LateUpdate()
    {
        if(!isRunning) return;
        ///TODO: Check distance
        transform.position = CalculateBesier(besierTime);
    }

}
