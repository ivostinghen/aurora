using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUnit : MonoBehaviour
{

    public Material powerOn;
    public Material powerOff;

    private Renderer[] renderers;
    private bool power;

    public void SetPower(bool activate) => this.power = activate;
    public bool GetPower() => this.power;


    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        if (transform.childCount == 0) ActivateVisualMagic();
    }

    public void RunMagic()
    {
        Controller.instance.DecreasePowerAmount();
        GetComponentInChildren<Animator>().enabled = true;
        ActivateVisualMagic();

    }

    public void ActivateVisualMagic()
    {
        foreach( Renderer r in renderers)
        {
            Material[] materials = r.materials;
            for(int i=0;i<materials.Length;i++)
            {
                if (materials[i].name.Equals("PowerOff (Instance)"))
                {
                    materials = r.materials;
                    materials[materials.Length - 1] = powerOn;
                    r.materials = materials;
                }
            }
           
            
        }
    }
}
