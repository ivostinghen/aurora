using UnityEngine;
using System.Collections;

public class FortLight : MonoBehaviour {


    float t = 0;
    public float speed;
    public Transform towerLight, towerCell, towerTop;



    void LateUpdate()
    {
        towerLight.Rotate (new Vector3(0, Time.deltaTime * speed, 0));
        towerTop.localPosition =new Vector3(0, Mathf.PingPong(Time.time* 2, 3F), 0);
        Vector3 randomRot= new Vector3(2F, 2F, 2F);
        towerTop.Rotate(randomRot);
        towerCell.Rotate(randomRot);
    }
}
