using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Renderer[] renderers;
    private bool power;

    public void SetPower(bool activate)=>this.power = activate;
    public bool GetPower() => this.power;


    private void Awake()
    {
        renderers = GetComponents<Renderer>();
    }
}
