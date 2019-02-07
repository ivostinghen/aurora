using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private BesierCurve besierCurve;

    private void Awake()
    {
        besierCurve = GetComponent<BesierCurve>();
        besierCurve.enabled = true;
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            besierCurve.RunBesier();
        }
    }
}
