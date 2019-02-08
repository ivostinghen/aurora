using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSphere : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Collider>().enabled = false;
        transform.parent.parent.GetComponent<MagicUnit>().RunMagic();
    }

    
}
