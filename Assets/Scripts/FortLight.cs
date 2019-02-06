using UnityEngine;
using System.Collections;

public class FortLight : MonoBehaviour {


    float t = 0;
    public float speed;
   // public float length;
    public Transform towerLight, towerCell, towerTop;



    void LateUpdate()
    {
        /* t = Mathf.PingPong(Time.time * speed, length);
        /towerLight.transform.localRotation = Quaternion.Slerp(Quaternion.Euler(0, 180, 0), Quaternion.Euler(0, 60, 0), t);

        transform.localRotation = Quaternion.Euler(t, 110, 0);*/


        //towerLight.localRotation = Quaternion.Euler(new Vector3(0, Mathf.PingPong(Time.time*speed,length), 0));
        towerLight.Rotate (new Vector3(0, Time.deltaTime * speed, 0));

        
        towerTop.localPosition =new Vector3(0, Mathf.PingPong(Time.time* 2, 3F), 0);
        Vector3 randomRot= new Vector3(2F, 2F, 2F);
        towerTop.Rotate(randomRot);
        towerCell.Rotate(randomRot);

    }
}
